using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    private float movespeed = 4;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        Debug.Log(name + "Game Object Click in Progress");
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + "No longer being clicked");
    }

    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(movespeed * Time.deltaTime, 0, 0);
        if (playerController.isCollided == true)
        {
            Debug.Log("Test Stop");
        }
    }
}
