using Cards.AttributeControllers.Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Utillites.Image;

namespace Cards.Art {
    public class ImageLoader : MonoBehaviour, IAttributeInitializer {

        [SerializeField]
        private Image _image;

        public bool isInitialized {
            get {
                return _isInitialized;
            }
            set {
                _isInitialized = value;
            }
        }

        private bool _isInitialized = false;

        public void Initialize(CardObject card) {
            if (_image == null) {
                _image = GetComponentInChildren<Image>();
            }

            StartCoroutine(DownloadImage($"https://picsum.photos/{card.ImageWidth}/{card.ImageHeight}"));
            isInitialized = true;
        }

        private IEnumerator DownloadImage(string url) {

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError) {
                Debug.Log(request.error);
            } else {
                Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
                _image.sprite = ImageUtils.SpriteFromTexture2D(webTexture);
            }
        }
    }
}
