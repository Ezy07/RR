using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowManBody : MonoBehaviour
{
    //Field
    #region .

    public Vector3 destination; //머리의 위치
    public float AnswearSize;

    private Transform Head; // 머리 위치변경 및 기능 삭제
    private float curTime = 0;  //Lerp를 위한 진행도
    private bool isHit = false; //머리가 몸에 부딫혔는지 확인용

    #endregion

    //Method
    #region .

    private bool IsSizeRight(Collision target)
    {
        if(target.transform.TryGetComponent<SnowManHead>(out var function))
        {
            if (function.CurSize == AnswearSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    #endregion

    //Unity Event
    #region .
    private void OnCollisionEnter(Collision target)
    {
        if (target.transform.CompareTag("SnowManHead") && IsSizeRight(target))
        {
            isHit = true; Head = target.transform;
            target.transform.SetParent(transform, true);
            Destroy(target.rigidbody); Destroy(target.collider);
        }
    }

    private void Update()
    {
        if (isHit)
        {
            curTime += Time.deltaTime;
            Vector3 startPos = Head.localPosition;
            Head.localPosition = Vector3.Lerp(startPos, destination, curTime / 10);
            transform.GetComponent<EndCheckPuzzle>().IsDone = true;
        }
    }

    #endregion
}
