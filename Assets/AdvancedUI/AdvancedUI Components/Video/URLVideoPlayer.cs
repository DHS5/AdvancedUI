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
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private RawImage rawImage;
        [SerializeField] private AspectRatioFitter ratioFitter;
        [SerializeField] private RenderTexture renderTexture;

        private void Awake()
        {
            videoPlayer.playOnAwake = playOnAwake;
            videoPlayer.url = url;
            videoPlayer.targetTexture = renderTexture;
            rawImage.texture = renderTexture;
        }

        private void OnEnable()
        {
            videoPlayer.started += SetRatio;
        }
        private void OnDisable()
        {
            videoPlayer.started -= SetRatio;
        }

        public void SetURLAndPlay(string URL)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
            }

            videoPlayer.url = URL;
            videoPlayer.Play();
        }

        private void SetRatio(VideoPlayer vp)
        {
            ratioFitter.aspectRatio = (float)vp.width / vp.height;
        }
    }
}
