using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManHead : InteractFunction
{
    //Field
    //도형 사이즈
    [Header("Setting")]
    public float[] SizeList;
    public int StartSizeIndex = 1;
    public float ChangeSpeed = 2.0f;

    [Header("Particle")]
    public ParticleSystem m_Particle;

    [HideInInspector]
    public float CurSize;

    //Check
    [Header("Check")]
    public bool IsGrabbed = false;
    public bool IsDone = false;
    private bool IsChanging = false;
    private float TargetSize;

    //Method

    public void IsGrab(bool value)
    {
        IsGrabbed = value;
    }

    //Override Method
    public override void ToolMainInteract()
    {
        if (!IsDone)
        {
            if (!IsChanging && !IsGrabbed)
            {
                BasicFunction();
                m_Particle.Play();
                SoundManager.instance.soundList[1].Play();
            }
        }
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

            gameObject.layer = 2;

            CurSize = Mathf.MoveTowards(CurSize, TargetSize, ChangeSpeed * Time.deltaTime);
            this.transform.localScale = new Vector3(CurSize, CurSize, CurSize);
        }
        else
        {
            IsChanging = false;

            gameObject.layer = 29;
        }
    }
    #endregion
}
