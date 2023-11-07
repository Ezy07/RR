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

    //Override
    #region .

    public override void CloseInteract()
    {
        Debug.Log("���� ����");
    }

    public override void EndInteract()
    {
        throw new System.NotImplementedException();
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
            Debug.Log("���� �� ����");
        }
        CurAmount = Amount;
    }
}
