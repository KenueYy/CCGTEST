using UnityEngine;
using UnityEngine.EventSystems;
using Utillites;

namespace Cards {
    public class CardDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

        private Vector2 _startPosition;
        private Vector2 _difference;

        public void OnPointerDown(PointerEventData eventData) {
            _startPosition = transform.position;
            _difference = _startPosition - MousePosition.GetPointerPositionOnWorldPoint(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData) {
            _startPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData) {
            Vector2 position = MousePosition.GetPointerPosition2D();
            gameObject.transform.position = position + _difference;
        }

    }
}
