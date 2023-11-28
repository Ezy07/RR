using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SummerPuzzleHandler : MonoBehaviour
{
    //Field
    //���� ���� ����Ʈ
    public List<int> AnswerColorIndexList;

    //�Ϸ��� ���� ����Ʈ(
    public List<GameObject> CheckPuzzle;

    //�Ϸ�� ����� ������ ������Ʈ
    public GameObject TriggerObject;

    private bool IsDone = false;

    //Method
    private IEnumerator DestroyFunction()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < CheckPuzzle.Count; i++)
        {
            GameObject target = CheckPuzzle[i];

            if (target != null && target.TryGetComponent<Potion>(out var targetFunc))
            {
                Destroy(targetFunc);
            }
        }

        Destroy(this);
    }

    private bool CheckAnswers(List<GameObject> objects)
    {
        //���� ����Ʈ ����
        List<int> answer = new(AnswerColorIndexList);

        //������Ʈ�� ���� ������ �ִ��� Ȯ��
        foreach (var obj in objects)
        {
            if (obj.TryGetComponent<Potion>(out var function))
            {
                if (answer.Contains(function.CurrentColorIndex))
                {
                    answer.Remove(function.CurrentColorIndex);
                }
                else { break; }
            }
            else { break; }
        }

        //��� ���� ������ T, �ƴϸ� F
        if (answer.Count == 0) { return true; }
        else { return false; }
    }
    
    //Unity Event
    private void Update()
    {
        //������ �Ϸ���� �ʾҴٸ�
        if (!IsDone)
        {
            //������ �������� Ȯ��
            if (CheckAnswers(CheckPuzzle))
            {
                if (TriggerObject.TryGetComponent<InteractFunction>(out var function))
                {
                    function.BasicFunction();
                    IsDone = true;
                }

                StartCoroutine(DestroyFunction());
            }
        }
    }
}
