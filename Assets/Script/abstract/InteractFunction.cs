using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractFunction : MonoBehaviour
{
    public bool InteractableTarget = false;

    //EŰ�� ���� ���
    public abstract void CloseInteract();

    //���⿡ ���� ���
    public abstract void WeaponInteract();

    //������ ������ ���
    public abstract void EndInteract();
}
