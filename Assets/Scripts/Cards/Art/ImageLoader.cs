using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Utillites.Image;

namespace Cards.Art {
    public class ImageLoader : MonoBehaviour {

        [SerializeField]
        private Image _image;

        private void Awake() {

            if (_image == null) {
                _image = GetComponentInChildren<Image>();
            }

            StartCoroutine(DownloadImage("https://picsum.photos/1800/900"));
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
