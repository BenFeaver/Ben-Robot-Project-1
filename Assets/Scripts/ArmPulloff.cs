using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPulloff : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    public bool beingDragged;

    void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
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
