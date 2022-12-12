using Cards;
using Cards.AttributeControllers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour, IAttributeInitializer {
    private IMutable<string> _titleUI;
    public void Initialize(CardObject card) {
        _titleUI = GetComponentInChildren<TitleUI>();
        _titleUI.SetValue(card.Title);
    }

}
