using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterPuzzleHandler : MonoBehaviour
{
    //�Ϸ��� ���� ����Ʈ(
    public List<GameObject> CheckPuzzle;
    public List<GameObject> DisablePuzzleAfterSolved;
    //�Ϸ�� ����� ������ ������Ʈ
    public GameObject TriggerObject;


    private bool IsAllTrue = true; //��� true���� Ȯ�ο�

    private void IsDone()
    {
        if (CheckPuzzle.Count > 0)
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
                for (int i = 0; i < DisablePuzzleAfterSolved.Count; i++)
                {
                    GameObject target = DisablePuzzleAfterSolved[i];

                    if (target != null && target.TryGetComponent<SnowManHead>(out var targetFunc))
                    {
                        Destroy(targetFunc);
                    }
                }

                for (int j = 0; j < CheckPuzzle.Count; j++)
                {
                    GameObject target = CheckPuzzle[j];

                    if (target != null && target.TryGetComponent<SnowManBody>(out var targetFunc))
                    {
                        Destroy(targetFunc);
                    }
                }

                //�ذ�� �����ϴ� ���
                Destroy(TriggerObject);

                Destroy(this);
            }
            else
            {
                //���ذ�� �����ϴ� ���

            }
        }
        else
        {
            Debug.Log("�ذ��� ������ �����ϴ�.");
        }

    }

    private void FixedUpdate()
    {
        IsDone();
    }
}