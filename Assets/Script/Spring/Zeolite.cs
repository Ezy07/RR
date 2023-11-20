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

    //������ ���Ḧ �˸�
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
    //����
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }
    //����
    public override void EndFunction()
    {
        throw new System.NotImplementedException();
    }
    //����
    public override void WeaponInteract()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
