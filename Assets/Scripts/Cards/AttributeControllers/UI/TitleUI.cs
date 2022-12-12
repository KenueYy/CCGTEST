using Cards.AttributeControllers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour, IMutable<string> {

    [SerializeField]
    private Text title;

    public void SetValue(string value) {
        title.text = value;
    }
}
