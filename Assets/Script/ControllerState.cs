using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerState : MonoBehaviour
{
    public static ControllerState instance = null;

    public XRRayInteractor Linteractor, Rinteractor;

    public bool isLeftControllerHovering
    {
        get { return isLeftControllerHovering; }
        set { isLeftControllerHovering = value;}
    }
    public bool isRightContorllerHovering
    {
        get { return !isRightContorllerHovering; }
        set { isRightContorllerHovering = value; }
    }

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
    }
}
