using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class SnowManBody : MonoBehaviour
{
    //Field
    #region .
    public Vector3 destination; //머리의 위치
    public float AnswearSize;

    private Transform Head; // 머리 위치변경 및 기능 삭제
    #endregion

    //Method
    #region .

    private bool IsSizeRight(Collision target)
    {
        if(target.transform.TryGetComponent<SnowManHead>(out var function))
        {
            if (function.CurSize == AnswearSize) { return true; }
            else { return false; }
        }
        else
        {
            return false;
        }
    }

    private IEnumerator HeadAttach(Collision target)
    {
        if(target.gameObject.TryGetComponent<SnowManHead>(out var function))
        {
            function.IsDone = true;
        }

        //충돌 위치 지정
        Head = target.transform;
        XRGrabInteractable grabFunction = target.gameObject.GetComponent<XRGrabInteractable>();
        Destroy(grabFunction); Destroy(target.rigidbody);

        float curT = 0f;
        float FinishingT = 2f;

        while (curT < FinishingT)
        {
            curT += Time.deltaTime;
            Vector3 startPos = Head.position;
            Head.position = Vector3.Lerp(startPos, transform.position + destination, curT / FinishingT);
            yield return null;
        }
        target.transform.SetParent(transform, true);
        transform.GetComponent<EndCheckPuzzle>().IsDone = true;
        Destroy(target.collider);
    }

    #endregion

    //Unity Event
    #region .
    private void OnCollisionEnter(Collision target)
    {
        if (target.transform.CompareTag("SnowManHead") && IsSizeRight(target))
        {
            StartCoroutine(HeadAttach(target));
        }
    }
    #endregion
}
