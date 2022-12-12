using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Utillites.Interfaces;

public class CardOutline : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //К сожалению я пока не могу в шедеры
    private ILabilized _outline;

    private void Awake() {
        _outline = GetComponentInChildren<OutlineUI>(true);
        _outline.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData) {
        _outline.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData) {
        _outline.SetActive(false);
    }
    

}
