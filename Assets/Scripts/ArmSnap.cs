using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmSnap : MonoBehaviour
{
    public GameObject SnapLocation;
    public bool isSnapped;
    private bool objectSnapped;
    private bool beingDragged;

    private Vector3 shoulderPosition;

    public Text changeText;
    
    private void Start()
    {
        shoulderPosition = gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        beingDragged = GetComponent<ArmPulloff>().beingDragged;
        objectSnapped = SnapLocation.GetComponent<ArmSnapLocation>().Snapped;
        if (objectSnapped == true && beingDragged == false)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = shoulderPosition;
           
        }
        ChangeText();
    }

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
