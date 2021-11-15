using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmSnap : MonoBehaviour
{
    public GameObject SnapLocation;
    private bool objectSnapped;
    private bool beingDragged;

    //Saves original arm position for being snapped
    private Vector3 shoulderPosition;

    //Keeps track of which text is associated with each object
    public Text changeText;
    
    private void Start()
    {
        shoulderPosition = gameObject.transform.position;
    }


    private void FixedUpdate()
    {
        beingDragged = GetComponent<ArmPulloff>().beingDragged;
        objectSnapped = SnapLocation.GetComponent<ArmSnapLocation>().Snapped;
        Snap();
        ChangeText();
    }

    //Snaps arm position
    private void Snap()
    {
        if (objectSnapped == true && beingDragged == false)
        {
            transform.position = shoulderPosition;
        }
    }

    //Changes associated text
    private void ChangeText()
    {
        if(objectSnapped == false)
        {
            changeText.text = "Arm is Detached";
        } else
        {
            changeText.text = "Arm is Attached";
        }
    }
    
}
