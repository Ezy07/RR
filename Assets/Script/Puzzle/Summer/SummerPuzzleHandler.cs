using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SummerPuzzleHandler : MonoBehaviour
{
    //Field
    //정답 색상 리스트
    public List<int> AnswerColorIndexList;

    //완료할 퍼즐 리스트(
    public List<GameObject> CheckPuzzle;

    //완료시 기능을 수행할 오브젝트
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
        //정답 리스트 복사
        List<int> answer = new(AnswerColorIndexList);

        //오브젝트가 값을 가지고 있는지 확인
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

        //모든 값이 있으면 T, 아니면 F
        if (answer.Count == 0) { return true; }
        else { return false; }
    }
    
    //Unity Event
    private void Update()
    {
        //퍼즐이 완료되지 않았다면
        if (!IsDone)
        {
            //퍼즐이 정답인지 확인
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
