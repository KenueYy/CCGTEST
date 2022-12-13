using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using System.Linq;
using Hand;

namespace Cards {

    public class Card : MonoBehaviour {

        private void Start() {
            Initialize();
        }
        private void Initialize() {

            CardObject cardObject = CardGenerator.Generate();
            GetComponentsInChildren<IAttributeInitializer>().ToList().ForEach(x => x.Initialize(cardObject));
        }
    }
}
