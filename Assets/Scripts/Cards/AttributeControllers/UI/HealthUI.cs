using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Cards.AttributeControllers.UI {

    public class HealthUI : MonoBehaviour, IMutable {

        [SerializeField]
        private Text health;

        public void SetValue(int value) {
            health.text = value.ToString();
        }
    }
}
