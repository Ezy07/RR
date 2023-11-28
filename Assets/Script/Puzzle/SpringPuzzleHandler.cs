using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpringPuzzleHandler : MonoBehaviour
{
    //�Ϸ��� ���� ����Ʈ(
    public List<GameObject> CheckPuzzle;
    public List<GameObject> DisablePuzzleAfterSolved;
    //�Ϸ�� ����� ������ ������Ʈ
    public GameObject TriggerObject;


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
                for(int i = 0; i < DisablePuzzleAfterSolved.Count; i++)
                {
                    GameObject target = DisablePuzzleAfterSolved[i];

                    if (target != null)
                    {
                        if (target.TryGetComponent<Sunflower>(out var targetFunc))
                        {
                            Destroy(targetFunc);
                        }
                        else if (CheckPuzzle[i].TryGetComponent<Zeolite>(out var targetFunc2))
                        {
                            Destroy(targetFunc2);
                        }
                    }
                }

                //�ذ�� �����ϴ� ���
                if (TriggerObject.TryGetComponent<InteractFunction>(out var function))
                {
                    function.BasicFunction();
                }

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
