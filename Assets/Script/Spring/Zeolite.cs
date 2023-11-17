using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeolite : InteractFunction
{
    //Override Method
    #region .

    //퍼즐의 종료를 알림
    public override void BasicFunction()
    {
        Debug.Log(" Done! ");
        if (transform.TryGetComponent<EndCheckPuzzle>(out var function))
        {
            function.IsDone = true;
        }
    }

    //Non Override
    //없음
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }
    //없음
    public override void EndFunction()
    {
        throw new System.NotImplementedException();
    }
    //없음
    public override void WeaponInteract()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
