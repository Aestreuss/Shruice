using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Juice : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonReleased;
  
    private void OnMouseDown()
    {
        Debug.Log("clicking");
        mouseButtonReleased = false; //checks for mouse
        // calculates offset between mouse position and the center of the game object that will be dragged (without this it will jump directly to the mouse pointer)
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true; //checks for mouse 
    }

}
