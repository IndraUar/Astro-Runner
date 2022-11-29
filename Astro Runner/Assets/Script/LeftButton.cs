using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressedLeft;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isPressedLeft = true;
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isPressedLeft = false;
    }
}
