using Cards.AttributeControllers.Interfaces;
using Hand;
using Hand.Interfaces;
using System.Collections;
using Table;
using UnityEngine;
using UnityEngine.EventSystems;
using Utillites;

namespace Cards.AttributeControllers {

    public class TransformController : MonoBehaviour, IAttributeInitializer, ICardTransform, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
        [SerializeField]
        private float speed;

        private IHand _hand;
        private CardCurve _cardCurve;

        private Vector3 _cardPosition;
        private Vector2 _startPosition;
        private Vector2 _difference;

        private int _index;
        private bool _isFrozen;
        private Card _parent;

        public bool isInitialized {
            get {
                return _isInitialized;
            }
            set {
                _isInitialized = value;
            }
        }

        private bool _isInitialized = false;

        #region IAttributeInitializer

        public void Initialize(CardObject card) {
            Connections();
            SetPoint();
            isInitialized = true;
        }

        #endregion

        #region Handlers
        public void OnPointerDown(PointerEventData eventData) {
            if (_isFrozen) {
                return;
            }

            StopCoroutine(nameof(GoBack));

            _hand.RemoveCard(_parent);
            _startPosition = transform.position;
            _difference = _startPosition - MousePosition.GetPointerPositionOnWorldPoint(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData) {
            if (_isFrozen || eventData.pointerCurrentRaycast.gameObject.GetComponent<DropToTable>() != null) {
                return;
            }

            _hand.AddCard(_parent);
            _startPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData) {
            if (_isFrozen) {
                return;
            }
            Vector2 position = MousePosition.GetPointerPosition2D();
            transform.position = position + _difference;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            transform.SetSiblingIndex(10);
        }

        public void OnPointerExit(PointerEventData eventData) {
            transform.SetSiblingIndex(0);
        }

        #endregion

        public void Freeze() {
            if (_isFrozen) {
                return;
            }
            _isFrozen = true;
            Vector2 position = MousePosition.GetPointerPosition2D();
            transform.position = position + _difference;

        }

        public void SetPoint() {
            _index = _hand.GetCardList().FindIndex(x => x == _parent);
            _cardPosition = _cardCurve.GetPoint(_index);
            StartCoroutine(nameof(GoBack));
        }

        private void Connections() {
            _parent = GetComponentInParent<Card>();
            _hand = FindObjectOfType<HandCards>();
            _cardCurve = FindObjectOfType<CardCurve>();
        }

        private IEnumerator GoBack() {
            while (transform.position != _cardPosition) {

                transform.position = Vector2.Lerp(transform.position, _cardPosition, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame(); 
            }
        }
    }
}
