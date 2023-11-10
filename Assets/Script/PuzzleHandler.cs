using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PuzzleHandler : MonoBehaviour
{
    //�Ϸ��� ���� ����Ʈ(
    public List<GameObject> CheckPuzzle;

    private bool IsAllTrue = true; //��� true���� Ȯ�ο�

    private void IsDone()
    {
        if(CheckPuzzle.Count > 0)
        {
            //��� ������ �ذ�Ǿ����� Ȯ��
            for (int i = 0; i < CheckPuzzle.Count; i++)
            {
                if (CheckPuzzle[i].TryGetComponent<EndCheckPuzzle>(out var function))
                {
                    if (!function.IsDone)
                    {
                        IsAllTrue = false;
                        break;
                    }
                    else
                    {
                        IsAllTrue = true;
                    }
                }
                else
                {
                    Debug.Log("������ ������ ������Ʈ�� �ƴմϴ�.");
                    break;
                }
            }

            //���� �ذ� ���ο� ���� ��� ����
            if (IsAllTrue)  //�ذ��
            {
                Debug.Log("���� ��� �ذ�");
            }
            else            //���ذ��
            {
                Debug.Log("���ذ� ���� ����");
            }
        }
        else
        {
            Debug.Log("�ذ��� ������ �����ϴ�.");
        }
        
    }

    private void OnValidate()
    {
        IsDone();
    }
}