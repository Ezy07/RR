using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManHead : InteractFunction
{
    //Field
    #region .

    public float GrowSize;

    #endregion

    //Override Method
    #region .
    public override void BasicFunction()
    {
        if (transform.localScale.x < 2)
        {
            transform.localScale += new Vector3(GrowSize, GrowSize, GrowSize);
        }
    }
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }

    public override void EndFunction()
    {
        throw new System.NotImplementedException();
    }

    public override void WeaponInteract()
    {
        BasicFunction();
    }
    #endregion

}
