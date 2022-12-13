using Hand.Interfaces;
using UnityEngine;
using Utillites;

namespace Hand {

    public class CardCurve : MonoBehaviour {
        private IHand _hand;

        [SerializeField]
        public Transform P0;

        [SerializeField]
        public Transform P1;

        [SerializeField]
        public Transform P2;

        [SerializeField]
        public Transform P3;

        private int _cardsCount;

        private void Awake() {
            _hand = FindObjectOfType<HandCards>();
        }

        public void CardsCountUpdate() {
            _cardsCount = _hand.GetCardList().Count;
            transform.localScale = new Vector3((float)_cardsCount/10,1,1);
        }

        public Vector2 GetPoint(int index) {
            CardsCountUpdate();
            float parameter = (1f / _cardsCount) * index;
            Vector2 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, parameter);
            return point;
        }

        private void OnDrawGizmos() {

            int sigmentsNumber = 20;
            Vector2 preveousePoint = P0.position;

            for (int i = 0; i < sigmentsNumber + 1; i++) {
                float paremeter = (float)i / sigmentsNumber;
                Vector2 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, paremeter);
                Gizmos.DrawLine(preveousePoint, point);
                preveousePoint = point;
            }

        }
    }
}
