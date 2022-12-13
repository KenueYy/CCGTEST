using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using System.Linq;
using Hand;
using Utillites.ObjectPooller;

namespace Cards {

    public class Card : MonoBehaviour {

        [ContextMenu("Initialize")]
        public void Initialize() {

            CardObject cardObject = CardGenerator.Generate();
            GetComponentsInChildren<IAttributeInitializer>().ToList().ForEach(x => x.Initialize(cardObject));
        }
        
    }
}
