using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : InteractFunction
{
    //Field
    #region .

    //내용물
    [Header("Cotent",order = 1),Space(5)]
    public GameObject Content;
    public float CotentChangeSpeed = 0.1f;
    public float IncreaseContentAmount = 0.25f;

    private Material Mat;
    private bool IsRising = false;
    private float CurrentContentAmount;
    private float TargetContentAmount;

    //색상
    [Header("Color", order = 2),Space(5)]
    public Color[] colors;
    public int StartColorIndex = 0;
    public float ColorChangeTime = 2.0f;

    private float CurColorTimer = 0.0f;
    private Color CurrentColor;
    private Color TargetColor;
    private bool IsChanging = false;

    //정답
    [Header("Answear", order = 3), Space(5)]
    public float ContentAmount;
    public int ColorIndex;

    #endregion

    //Method
    #region .

    //이펙트 수행
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
        //내용물 초기화
        Mat = Content.GetComponent<MeshRenderer>().material;
        CurrentContentAmount = Mat.GetFloat("_Fill");
        TargetContentAmount = CurrentContentAmount;

        //색상 초기화
        CurrentColor = colors[StartColorIndex];
        TargetColor = colors[StartColorIndex];
        Mat.SetColor("_Color", TargetColor);
    }

    private void Update()
    {
        //내용물 처리
        if(CurrentContentAmount != TargetContentAmount)
        {
            // 내용물의 양이 변할 때
            IsRising = true;

            // 내용물의 양 변화
            CurrentContentAmount = Mathf.MoveTowards(CurrentContentAmount, TargetContentAmount, CotentChangeSpeed * Time.deltaTime);
            Mat.SetFloat("_Fill", CurrentContentAmount);

            // 이펙트 처리
            UpdateContentVisuals();
        }
        else
        {
            //내용물의 양이 변하지 않을 때
            IsRising = false;
            CurrentContentAmount = TargetContentAmount;
        }

        if(CurrentColor != colors[StartColorIndex])
        {
            float timer;

            //색상이 변할 때
            IsChanging = true;

            CurColorTimer += 1 * Time.deltaTime;
            timer = Mathf.MoveTowards(0, 1, CurColorTimer / ColorChangeTime * Time.deltaTime);

            //색상 처리
            CurrentColor = Color.Lerp(CurrentColor, TargetColor, timer);
            Mat.SetColor("_Color", CurrentColor);
        }
        else
        {
            //색상이 변하지 않을 때
            IsChanging = false;
            CurColorTimer = 0.0f;
            CurrentColor = TargetColor;
        }

        //조건 만족시 퍼즐 확인
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
