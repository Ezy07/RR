using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderSpotLight : MonoBehaviour
{
    //Unity Event
    #region .
    private void OnTriggerEnter(Collider target)
    {
        KeyFunction.instance.OnLight = true;
    }

    private void OnTriggerExit(Collider target)
    {
        KeyFunction.instance.OnLight = false;
    }

    #endregion

}
