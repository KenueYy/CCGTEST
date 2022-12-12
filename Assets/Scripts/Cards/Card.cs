using Cards;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
