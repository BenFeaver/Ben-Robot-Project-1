using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlight : MonoBehaviour
{
    //bool to check if an arm is highlighted
    public static bool isArmHighlighted = false;
    
    /*Strings set up to check if the tag of a Game Object
    matches that of the game object that is currently being hovered
    over. This is so all of the right/left arm is highlighted instead of
    just one piece, but also so both arms dont highlight*/
    public static string tagCheck;
    public string nothingHighlighted = " ";

    //Colors used to change color of a Material upon being highlighted
    private Color startingColor;
    private Color highlightColor = Color.yellow;
    Material robotMat;

    private void Start()
    {
        robotMat = GetComponent<MeshRenderer>().material;
        tagCheck = nothingHighlighted;
        startingColor = robotMat.color;
    }

    private void FixedUpdate()
    {
        HighlightArm();
    }

    private void HighlightArm()
    {
        /*Function checks to see if the object tag matches the object being hovered over, then
         sets the object Material color to highlight it. Highlights all objects with that tag*/
        if (isArmHighlighted == true && gameObject.CompareTag(tagCheck))
        { robotMat.color = highlightColor; }
        else robotMat.color = startingColor;
    }

    private void OnMouseEnter()
    {
        isArmHighlighted = true;
        tagCheck = gameObject.tag;
    }
    private void OnMouseExit()
    {
        isArmHighlighted = false;
        tagCheck = nothingHighlighted;
    }

}
