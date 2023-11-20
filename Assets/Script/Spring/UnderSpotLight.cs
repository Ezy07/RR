using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderSpotLight : MonoBehaviour
{
    //Unity Event
    #region .
    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            KeyFunction.instance.OnLight = true;
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            KeyFunction.instance.OnLight = false;
        }
    }

    #endregion

}
