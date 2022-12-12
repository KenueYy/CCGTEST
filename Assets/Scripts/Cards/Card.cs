using Cards;
using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using System.Linq;

public class Card : MonoBehaviour
{

    private void Awake() {
        Initialize();
    }
    private void Initialize() {
        
        CardObject cardObject = CardGenerator.Generate();
        GetComponentsInChildren<IAttributeInitializer>().ToList().ForEach(x => x.Initialize(cardObject));
    }
}
