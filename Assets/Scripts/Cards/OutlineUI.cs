using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utillites.Interfaces;

public class OutlineUI : MonoBehaviour, ILabilized {

    public void SetActive(bool value) {
        gameObject.SetActive(value);
    }
}
