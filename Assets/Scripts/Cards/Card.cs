using Cards;
using Cards.AttributeControllers.Interfaces;
using UnityEngine;

public class Card : MonoBehaviour
{
    private CardObject cardObject;

    private void Awake() {
        Initialize();
    }
    private void Initialize() {
        cardObject = new CardObject() {
            Manacost = 5,
            Title = "dsad",
            Description = "sdad",
            Attack = 6,
            Health = 7
        };

        GetComponentInChildren<IAttributeController>().Initialize(cardObject.Health);
    }
}
