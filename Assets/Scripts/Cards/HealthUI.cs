using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour, IMutable
{
    [SerializeField]
    private Text health;

    public void SetValue(int value) {
        health.text = value.ToString();
    }
}
