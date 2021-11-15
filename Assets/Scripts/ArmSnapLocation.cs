using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSnapLocation : MonoBehaviour
{
    private bool inDragState;
    private bool insideSnapZone;
    public bool Snapped;
    public GameObject Arm;
    //public GameObject SnapRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Arm.name)
        {
            insideSnapZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Arm.name)
        {
            insideSnapZone = false;
        }
    }

    void SnapToShoulder()
    {
        if (inDragState == false && insideSnapZone == true)
        {
            Snapped = true;
        }
        else
            Snapped = false;
    }

    private void Update()
    {
        inDragState = Arm.GetComponent<ArmPulloff>().beingDragged;
        SnapToShoulder();
    }
}
