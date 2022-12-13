using UnityEngine;
using UnityEngine.EventSystems;
using Utillites.Interfaces;

namespace Cards {

    public class CardOutline : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {
        //К сожалению я пока не могу в шедеры
        private ILabilized _outline;

        private void Awake() {
            _outline = GetComponentInChildren<OutlineUI>(true);
            _outline.SetActive(false);
        }

        public void OnPointerExit(PointerEventData eventData) {
            _outline.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData) {
            _outline.SetActive(true);
        }
    }
}
