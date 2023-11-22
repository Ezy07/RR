using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeolite : InteractFunction
{
    //Field
    #region .

    public ParticleSystem ParticleSystem;

    #endregion

    //Override Method
    #region .

    //퍼즐의 종료를 알림
    public override void BasicFunction()
    {
        Debug.Log(" Done! ");
        if (transform.TryGetComponent<EndCheckPuzzle>(out var function))
        {
            function.IsDone = true;
            ParticleSystem.Play();
        }
    }

    //Non Override
    //없음
    public override void ToolSubInteract()
    {
        throw new System.NotImplementedException();
    }
    //없음
    public override void ToolMainInteract()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
