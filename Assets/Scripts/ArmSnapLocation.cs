using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSnapLocation : MonoBehaviour
{
    //Retrieve drag state
    private bool beingDragged;

    //Variables to determine whether the arm should snap into place or not
    private bool insideSnapZone;
    public bool Snapped;
    public GameObject Arm;
    
    //Determines if the Arm is within the shoulder sphere colliders
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

    //Sets snap state if in the specified zone and also not being dragged
    void SnapToShoulder()
    {
        if (beingDragged == false && insideSnapZone == true)
        {
            Snapped = true;
        }
        else
            Snapped = false;
    }

    //Sets Drag state and runs the Snap check
    private void Update()
    {
        beingDragged = Arm.GetComponent<ArmPulloff>().beingDragged;
        SnapToShoulder();
    }
}
