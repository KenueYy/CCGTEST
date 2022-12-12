using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using UnityEngine.UI;


namespace Cards.AttributeControllers.UI {

    public class AttackUI : MonoBehaviour, IMutable<int> {

        [SerializeField]
        private Text attack;

        public void SetValue(int value) {
            attack.text = value.ToString();
        }
    }
}
