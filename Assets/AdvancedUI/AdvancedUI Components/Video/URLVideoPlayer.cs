using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Dhs5.AdvancedUI
{
    public class URLVideoPlayer : MonoBehaviour
    {
        [Header("Content")]
        [SerializeField] private string url;
        [SerializeField] private bool playOnAwake;

        [Header("References")]
        [SerializeField] private RectTransform mainRect;
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private RawImage rawImage;
        [SerializeField] private AspectRatioFitter ratioFitter;
        [SerializeField] private RenderTexture renderTexture;
        [Space]
        [SerializeField] private GameObject actionsScreen;
        [SerializeField] private AdvancedToggle playPauseToggle;
        [SerializeField] private AdvancedSlider timeSlider;

        private bool isPlaying;
        private bool canStart;
        private bool canUnsuspend;

        readonly float timePrecision = 0.01f;

        private void Awake()
        {
            videoPlayer.playOnAwake = playOnAwake;
            isPlaying = playOnAwake;
            playPauseToggle.State = playOnAwake;
            videoPlayer.url = url;
            videoPlayer.targetTexture = renderTexture;
            rawImage.texture = renderTexture;
        }

        private void Start()
        {
            SetURL("https://user-images.githubusercontent.com/94963203/181253439-5768f985-5da1-48f2-9180-d7a71df451ff.mp4");
        }

        private void OnEnable()
        {
            videoPlayer.prepareCompleted += VideoReady;
            videoPlayer.loopPointReached += End;
            videoPlayer.seekCompleted += SeekComplete;
            playPauseToggle.OnTrue += PlayVideo;
            playPauseToggle.OnFalse += PauseVideo;
            timeSlider.OnButtonDown += SuspendVideo;
            timeSlider.OnButtonUp += UnsuspendVideo;

        }
        private void OnDisable()
        {
            videoPlayer.prepareCompleted -= VideoReady;
            videoPlayer.loopPointReached -= End;
            videoPlayer.seekCompleted -= SeekComplete;
            playPauseToggle.OnTrue -= PlayVideo;
            playPauseToggle.OnFalse -= PauseVideo;
            timeSlider.OnButtonDown -= SuspendVideo;
            timeSlider.OnButtonUp -= UnsuspendVideo;
        }

        private void Update()
        {
            if (videoPlayer.isPlaying)
            {
                timeSlider.SliderValue = (float)videoPlayer.frame / videoPlayer.frameCount;
            }
        }

        #region Listeners
        private void VideoReady(VideoPlayer vp)
        {
            SetRatio(vp);

            if (canStart)
                PlayVideo();

            canStart = false;
        }
        private void PlayVideo()
        {
            if (!videoPlayer.isPrepared) return;

            videoPlayer.Play();
            isPlaying = true;
        }
        private void PauseVideo()
        {
            if (!videoPlayer.isPrepared) return;

            videoPlayer.Pause();
            isPlaying = false;
        }
        private void End(VideoPlayer vp)
        {
            videoPlayer.frame = 0;
            playPauseToggle.State = false;
        }
        private void SuspendVideo()
        {
            videoPlayer.Pause();
        }
        private void UnsuspendVideo()
        {
            videoPlayer.time = timeSlider.SliderValue * videoPlayer.length;
            canUnsuspend = true;
        }
        private void SeekComplete(VideoPlayer vp)
        {
            if (canUnsuspend)
            {
                if (isPlaying)
                    videoPlayer.Play();
                canUnsuspend = false;
            }
        }
        #endregion

        public void SetURLAndPlay(string URL)
        {
            canStart = true;
            playPauseToggle.State = true;

            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
            }

            videoPlayer.url = URL;
            videoPlayer.Prepare();
        }
        public void SetURL(string URL)
        {
            canStart = false;
            if (videoPlayer.isPlaying)
            {
                PauseVideo();
            }

            videoPlayer.url = URL;
            videoPlayer.Prepare();
        }

        private void SetRatio(VideoPlayer vp)
        {
            ratioFitter.aspectRatio = (float)vp.width / vp.height;
            mainRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rawImage.rectTransform.rect.height);
        }
    }
}
