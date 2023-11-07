using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeolite : InteractFunction
{

    //Override Method
    #region .
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }

    public override void EndInteract()
    {
        if (transform.TryGetComponent<EndCheckPuzzle>(out var function))
        {
            function.IsDone = true;
        }
    }

    public override void WeaponInteract()
    {
        throw new System.NotImplementedException();
    }

    #endregion

}
