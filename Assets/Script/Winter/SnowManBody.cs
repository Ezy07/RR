using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowManBody : MonoBehaviour
{
    //Field
    #region .

    public float min, max;  // �Ӹ��� ũ��
    public Vector3 destination; //�Ӹ��� ��ġ

    private Transform Head; // �Ӹ� ��ġ���� �� ��� ����
    private float curTime = 0;  //Lerp�� ���� ���൵
    private bool isHit = false; //�Ӹ��� ���� �΋H������ Ȯ�ο�

    #endregion

    //Method
    #region .

    private bool IsSizeRight(Collision target)
    {
        if (min <= target.transform.localScale.x && target.transform.localScale.x <= max)
        {
            return true;
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