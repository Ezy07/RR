using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerWall : InteractFunction
{
    public override void BasicFunction()
    {
        if(this.TryGetComponent<Animator>(out var function))
        {
            function.SetTrigger("IsOpen");
        }
    }

    public override void ToolMainInteract()
    {
        throw new System.NotImplementedException();
    }
}
