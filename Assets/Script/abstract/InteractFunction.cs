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
    //EŰ�� ���� ���
    public abstract void ToolSubInteract();

    //���⿡ ���� ���
    public abstract void ToolMainInteract();
    #endregion

    //Object Function
    #region .
    //������ �⺻ ���
    public abstract void BasicFunction();

    #endregion
}
