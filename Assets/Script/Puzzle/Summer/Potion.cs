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

    //내용물
    [Header("Cotent",order = 1),Space(5)]
    public GameObject Content;
    public float CotentChangeSpeed = 0.1f;
    public float IncreaseContentAmount = 0.25f;

    private Material Mat;

    //색상
    [Header("Color", order = 2),Space(5)]
    public Color[] colors;
    public int CurrentColorIndex = 0;
    public float ColorChangeTime = 2.0f;

    private Color CurColor;
    private Color TargetColor;
    private bool IsChanging = false;

    //파티클
    [Header("Particle System", order = 3), Space(5)]
    public ParticleSystem particle;

    #endregion

    //Method
    #region .

    //색상 변경
    private IEnumerator ChangeColor(float changingTime)
    {
        float timer = changingTime;
        Color tempColor;

        //색상이 변할 때
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

    //이펙트 수행
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
            SoundManager.instance.soundList[1].Play();
            CurrentColorIndex = (CurrentColorIndex + 1) % colors.Length;
            TargetColor = colors[CurrentColorIndex];
            StartCoroutine(ChangeColor(ColorChangeTime));
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
        Mat = Content.GetComponent<MeshRenderer>().material;

        //색상 초기화
        CurColor = colors[CurrentColorIndex];
        TargetColor = colors[CurrentColorIndex];
        Mat.SetColor("_Color", TargetColor);
    }
    #endregion

}
