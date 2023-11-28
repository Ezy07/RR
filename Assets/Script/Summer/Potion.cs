using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    public int CurrentColorIndex = 0;
    public float ColorChangeTime = 2.0f;

    private Color CurColor;
    private Color TargetColor;
    private bool IsChanging = false;

    //��ƼŬ
    [Header("Particle System", order = 3), Space(5)]
    public ParticleSystem particle;


    #endregion

    //Method
    #region .

    //���� ����
    private IEnumerator ChangeColor(float changingTime)
    {
        float timer = changingTime;
        Color tempColor;

        //������ ���� ��
        IsChanging = true;
        ColorChangeVisuals();

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            tempColor = Color.Lerp(CurColor, TargetColor, 1 - timer / changingTime);
            Mat.SetColor("_Color", tempColor);
            yield return null;
        }
        CurColor = TargetColor;
        IsChanging = false;
    }

    //����Ʈ ����
    private void ColorChangeVisuals()
    {
        particle.Play();
    }

    #endregion

    //Override Method
    #region .
    public override void ToolMainInteract()
    {
        if (!IsChanging)
        {
            CurrentColorIndex = (CurrentColorIndex + 1) % colors.Length;
            TargetColor = colors[CurrentColorIndex];
            StartCoroutine(ChangeColor(ColorChangeTime));
        }
    }
    public override void ToolSubInteract()
    {
        //if (!IsRising)
        //{
        //    TargetContentAmount += IncreaseContentAmount;
        //    if (TargetContentAmount > 1f)
        //    {
        //        TargetContentAmount = 0.0f;
        //    }
        //}
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
        Mat = Content.GetComponent<MeshRenderer>().material;

        ////���빰 �ʱ�ȭ
        //CurrentContentAmount = Mat.GetFloat("_Fill");
        //TargetContentAmount = CurrentContentAmount;

        //���� �ʱ�ȭ
        CurColor = colors[CurrentColorIndex];
        TargetColor = colors[CurrentColorIndex];
        Mat.SetColor("_Color", TargetColor);
    }

    private void Update()
    {
        ////���빰 ó��
        //if(CurrentContentAmount != TargetContentAmount)
        //{
        //    // ���빰�� ���� ���� ��
        //    IsRising = true;

        //    // ���빰�� �� ��ȭ
        //    CurrentContentAmount = Mathf.MoveTowards(CurrentContentAmount, TargetContentAmount, CotentChangeSpeed * Time.deltaTime);
        //    Mat.SetFloat("_Fill", CurrentContentAmount);

        //    // ����Ʈ ó��
        //    UpdateContentVisuals();
        //}
        //else
        //{
        //    //���빰�� ���� ������ ���� ��
        //    IsRising = false;
        //    CurrentContentAmount = TargetContentAmount;
        //}
    }
    #endregion

}
