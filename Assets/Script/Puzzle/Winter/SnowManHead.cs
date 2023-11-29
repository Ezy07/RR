using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManHead : InteractFunction
{
    //Field
    //도형 사이즈
    public float[] SizeList;
    public int StartSizeIndex = 1;
    public float ChangeSpeed = 2.0f;

    [HideInInspector]
    public float CurSize;

    private bool IsGrabbed
    {
        get { return IsGrabbed; }
        set { IsGrabbed = value; }
    }
    private bool IsChanging = false;
    private float TargetSize;

    //Method
    //Override Method
    public override void ToolMainInteract()
    {
        if (!IsChanging && IsGrabbed)
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

    //Unity Event
    #region .
    private void Start()
    {
        CurSize = SizeList[StartSizeIndex];
        TargetSize = CurSize;
        this.transform.localScale = new Vector3(CurSize, CurSize, CurSize);
    }

    private void Update()
    {
        if (CurSize != TargetSize)
        {
            IsChanging = true;

            CurSize = Mathf.MoveTowards(CurSize, TargetSize, ChangeSpeed * Time.deltaTime);
            this.transform.localScale = new Vector3(CurSize, CurSize, CurSize);
        }
        else
        {
            IsChanging = false;
        }
    }
    #endregion
}
