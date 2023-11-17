using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : InteractFunction
{
    //Field
    #region .
    public GameObject Content;
    public double ChangeSpeed = 0.0;

    private Material Mat;
    private double CurAmount;
    private double Amount;

    
    #endregion

    //Override Method
    #region .

    public override void CloseInteract()
    {
        Debug.Log("색상 변경");
    }
    public override void BasicFunction()
    {
        throw new NotImplementedException();
    }

    public override void EndFunction()
    {
        throw new NotImplementedException();
    }

    public override void WeaponInteract()
    {
        if (Amount < 1)
        {
            Amount += ChangeSpeed * Time.deltaTime;
        }
        else
        {
            Amount = 0;
        }
    }

    #endregion

    //Unity Event
    #region .
    // Start is called before the first frame update
    void Start()
    {
        Mat = Content.GetComponent<MeshRenderer>().material;
        Amount = Mat.GetFloat("_Fill");
        CurAmount = Amount;
    }

    private void Update()
    {
        if (CurAmount != Amount)
        {
            Mat.SetFloat("_Fill", (float)Amount);
            Debug.Log("포션 양 변경");
        }
        CurAmount = Amount;
    }
    #endregion

}
