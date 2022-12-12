using Cards.AttributeControllers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utillites.Interfaces;

public class DescriptionsUI : MonoBehaviour, IMutable<string>, ILabilized {

    [SerializeField]
    private Text descriptions;

    public void SetActive(bool value) {
        gameObject.SetActive(value);
    }

    public void SetValue(string value) {
        descriptions.text = value;
    }
}
