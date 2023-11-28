using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManHead : InteractFunction
{
    //Field
    #region .

    //도형 색상

    //도형 사이즈
    public Transform Target;

    public float[] SizeList;
    public int StartSizeIndex = 1;
    public float ChangeSpeed = 2.0f;

    [HideInInspector]
    public float CurSize;

    private bool IsChanging = false;
    private float TargetSize;

    #endregion

    //Method
    #region .

    #endregion

    //Override Method
    #region .
    public override void ToolMainInteract()
    {
        if (!IsChanging)
        {
            BasicFunction();
        }
    }

    public override void ToolSubInteract()
    {
        
    }

    public override void BasicFunction()
    {
        StartSizeIndex = (StartSizeIndex + 1) % SizeList.Length;
        TargetSize = SizeList[StartSizeIndex];
    }

    #endregion

    //Unity Event
    #region .
    private void Start()
    {
        CurSize = SizeList[StartSizeIndex];
        TargetSize = CurSize;
        Target.transform.localScale = new Vector3(CurSize, CurSize, CurSize);
    }

    private void Update()
    {
        if (CurSize != TargetSize)
        {
            IsChanging = true;

            CurSize = Mathf.MoveTowards(CurSize, TargetSize, ChangeSpeed * Time.deltaTime);
            Target.transform.localScale = new Vector3(CurSize, CurSize, CurSize);
        }
        else
        {
            IsChanging = false;
        }
    }

    #endregion
}
