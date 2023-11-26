using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //Field
    #region .

    public static PlayerState instance = null;

    public bool PlayerIsOnLight = false;

    #endregion

    //Unity Event
    #region .

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion
}
