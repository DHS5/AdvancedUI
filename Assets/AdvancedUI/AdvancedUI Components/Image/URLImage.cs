using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

namespace Dhs5.AdvancedUI
{
    public class URLImage : MonoBehaviour
    {
        [Header("Content")]
        [SerializeField] private bool setOnStart;
        [SerializeField] private string url;

        [Header("References")]
        [SerializeField] private RawImage image;
        [SerializeField] private AspectRatioFitter ratioFitter;

        public event Action onSetRatio;

        private void Start()
        {
            if (setOnStart)
                SetTexture(url);
        }

        public void SetTexture(string URL)
        {
            StartCoroutine(DownloadAndSetTextureCR(URL, image));
        }

        private IEnumerator DownloadAndSetTextureCR(string URL, RawImage rawImage)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(URL);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                Debug.Log(request.error);
            else
            {
                SetTextureAndRatio(((DownloadHandlerTexture)request.downloadHandler).texture, rawImage);
            }
        }

        private void SetTextureAndRatio(Texture2D texture, RawImage rawImage)
        {
            ratioFitter.aspectRatio = (float)texture.width / texture.height;
            rawImage.texture = texture;

            onSetRatio?.Invoke();
        }
    }
}
