using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPulloff : MonoBehaviour
{
    //Variables to help determine mouse position in World space and where to move the object
    private Vector3 mouseOffset;
    private float mouseZCoord;

    public bool beingDragged;

    /*Assigns the mouse z coordinate to the game objects z position, and keeps track of the mouse position in relation
    to the Game Object position*/ 
    void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    //Translates the mouse position from the screen to the 3D world space
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    //Moves object based on Mouse Positioning as its dragged, sets the drag state
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mouseOffset;
        beingDragged = true;
    }

    private void OnMouseUp()
    {
        beingDragged = false;
    }

    private void Start()
    {
        beingDragged = false;
    }
}
