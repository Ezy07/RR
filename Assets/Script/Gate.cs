using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : InteractFunction
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void BasicFunction()
    {
        animator.SetBool("IsOpen", true);
    }

    public override void EndFunction()
    {
        throw new System.NotImplementedException();
    }

    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }

    public override void WeaponInteract()
    {
        throw new System.NotImplementedException();
    }
}
