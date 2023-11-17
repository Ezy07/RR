using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractFunction : MonoBehaviour
{
    //Field
    #region .

    public bool StartTarget = false;

    #endregion

    //Player Interact Function
    #region .
    //EŰ�� ���� ���
    public abstract void CloseInteract();

    //���⿡ ���� ���
    public abstract void WeaponInteract();
    #endregion

    //Object Function
    #region .
    //������ �⺻ ���
    public abstract void BasicFunction();

    //������ ������ ���
    public abstract void EndFunction();
    #endregion
}
