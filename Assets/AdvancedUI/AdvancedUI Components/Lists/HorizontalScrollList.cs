using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    public class HorizontalScrollList : MonoBehaviour
    {
        [Header("Content")]
        [OnValueChanged(nameof(ResizeSockets))]
        public float previewWidth = 100;

        [Space, Space]
        [Header("UI Components")]
        [SerializeField] private RectTransform socketContainer;

        [Space, Space]
        [Header("Sockets")]
        [SerializeField] private GameObject mainSocket;
        [ShowNativeProperty] public int VisiblePreviewsNumber => sockets.Count - 2;
        [ShowNativeProperty] public int TotalPreviewNumber => sockets.Count;

        [ReadOnly][SerializeField] List<GameObject> sockets = new();

        #region Socket Management

        [Button("Add 2 sockets")]
        private void Add()
        {
            AddSocket(true);
            AddSocket(false);
        }
        private void AddSocket(bool first)
        {
            GameObject socket = Instantiate(mainSocket, socketContainer);
            socket.name = "socket " + TotalPreviewNumber;
            (socket.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, previewWidth);
            if (first) socket.transform.SetAsFirstSibling();
            sockets.Add(socket);
        }
        [Button("Remove 2 sockets")]
        private void Remove()
        {
            if (TotalPreviewNumber < 3) return;
            RemoveSocket();
            RemoveSocket();
        }
        private void RemoveSocket()
        {
            GameObject socket = sockets[TotalPreviewNumber - 1];
            sockets.Remove(socket);
            DestroyImmediate(socket);
        }
        [Button("Reset sockets")]
        private void ResetSockets()
        {
            foreach (var socket in sockets)
                if (socket != mainSocket)
                    DestroyImmediate(socket);
            sockets.Clear();
            sockets.Add(mainSocket);
        }

        private void ResizeSockets()
        {
            foreach(var socket in sockets)
                (socket.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, previewWidth);
        }
        #endregion
    }
}
