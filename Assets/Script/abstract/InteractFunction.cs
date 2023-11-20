using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractFunction : MonoBehaviour
{
    //Field
    #region .

    public bool IsStartTarget = false;

    #endregion

    //Player Interact Function
    #region .
    //E키에 의한 기능
    public abstract void CloseInteract();

    //무기에 의한 기능
    public abstract void WeaponInteract();
    #endregion

    //Object Function
    #region .
    //퍼즐의 기본 기능
    public abstract void BasicFunction();

    //퍼즐의 마지막 기능
    public abstract void EndFunction();
    #endregion
}
