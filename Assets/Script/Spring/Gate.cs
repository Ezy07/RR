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

    public override void ToolSubInteract()
    {
        throw new System.NotImplementedException();
    }

    public override void ToolMainInteract()
    {
        throw new System.NotImplementedException();
    }
}
