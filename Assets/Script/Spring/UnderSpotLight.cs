using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderSpotLight : MonoBehaviour
{
    private void OnTriggerEnter(Collider target)
    {
        if(target.TryGetComponent<KeyFunction>(out var function))
        {
            function.OnLight = true;
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if(target.TryGetComponent<KeyFunction>(out var function))
        {
            function.OnLight = false;
        }
    }
}
