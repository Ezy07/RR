using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : InteractFunction
{
    //Field
    #region .

    //���빰
    [Header("Cotent",order = 1),Space(5)]
    public GameObject Content;
    public float CotentChangeSpeed = 0.1f;
    public float IncreaseContentAmount = 0.25f;

    private Material Mat;
    private bool IsRising = false;
    private float CurrentContentAmount;
    private float TargetContentAmount;

    //����
    [Header("Color", order = 2),Space(5)]
    public Color[] colors;
    public int StartColorIndex = 0;
    public float ColorChangeTime = 2.0f;

    private float CurColorTimer = 0.0f;
    private Color CurrentColor;
    private Color TargetColor;
    private bool IsChanging = false;

    //����
    [Header("Answear", order = 3), Space(5)]
    public float ContentAmount;
    public int ColorIndex;

    #endregion

    //Method
    #region .

    //����Ʈ ����
    private void UpdateContentVisuals()
    {
        
    }

    #endregion

    //Override Method
    #region .
    public override void ToolMainInteract()
    {
        if (!IsRising)
        {
            TargetContentAmount += IncreaseContentAmount;
            if (TargetContentAmount > 1f)
            {
                TargetContentAmount = 0.0f;
            }
        }
    }
    public override void ToolSubInteract()
    {
        if (!IsChanging)
        {
            StartColorIndex = (StartColorIndex + 1) % colors.Length;
            TargetColor = colors[StartColorIndex];
        }
    }
    public override void BasicFunction()
    {
        throw new NotImplementedException();
    }

    #endregion

    //Unity Event
    #region .
    // Start is called before the first frame update
    void Start()
    {
        //���빰 �ʱ�ȭ
        Mat = Content.GetComponent<MeshRenderer>().material;
        CurrentContentAmount = Mat.GetFloat("_Fill");
        TargetContentAmount = CurrentContentAmount;

        //���� �ʱ�ȭ
        CurrentColor = colors[StartColorIndex];
        TargetColor = colors[StartColorIndex];
        Mat.SetColor("_Color", TargetColor);
    }

    private void Update()
    {
        //���빰 ó��
        if(CurrentContentAmount != TargetContentAmount)
        {
            // ���빰�� ���� ���� ��
            IsRising = true;

            // ���빰�� �� ��ȭ
            CurrentContentAmount = Mathf.MoveTowards(CurrentContentAmount, TargetContentAmount, CotentChangeSpeed * Time.deltaTime);
            Mat.SetFloat("_Fill", CurrentContentAmount);

            // ����Ʈ ó��
            UpdateContentVisuals();
        }
        else
        {
            //���빰�� ���� ������ ���� ��
            IsRising = false;
            CurrentContentAmount = TargetContentAmount;
        }

        if(CurrentColor != colors[StartColorIndex])
        {
            float timer;

            //������ ���� ��
            IsChanging = true;

            CurColorTimer += 1 * Time.deltaTime;
            timer = Mathf.MoveTowards(0, 1, CurColorTimer / ColorChangeTime * Time.deltaTime);

            //���� ó��
            CurrentColor = Color.Lerp(CurrentColor, TargetColor, timer);
            Mat.SetColor("_Color", CurrentColor);
        }
        else
        {
            //������ ������ ���� ��
            IsChanging = false;
            CurColorTimer = 0.0f;
            CurrentColor = TargetColor;
        }

        //���� ������ ���� Ȯ��
        if(CurrentContentAmount == ContentAmount && CurrentColor == colors[ColorIndex])
        {
            if(this.TryGetComponent<EndCheckPuzzle>(out EndCheckPuzzle target))
            {
                target.IsDone = true;
            }
        }
    }
    #endregion

}
