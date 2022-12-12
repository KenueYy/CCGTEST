using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using UnityEngine.UI;


namespace Cards.AttributeControllers.UI {

    public class ManacostUI : MonoBehaviour, IMutable {

        [SerializeField]
        private Text manacost;

        public void SetValue(int value) {
            manacost.text = value.ToString();
        }
    }
}
