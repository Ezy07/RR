using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractFunction : MonoBehaviour
{
    public bool InteractableTarget = false;

    //E키에 의한 기능
    public abstract void CloseInteract();

    //무기에 의한 기능
    public abstract void WeaponInteract();

    //마지막 퍼즐의 기능
    public abstract void EndInteract();
}
