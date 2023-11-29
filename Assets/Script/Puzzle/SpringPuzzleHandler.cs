using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpringPuzzleHandler : MonoBehaviour
{
    //완료할 퍼즐 리스트(
    public List<GameObject> CheckPuzzle;
    public List<GameObject> DisablePuzzleAfterSolved;
    //완료시 기능을 수행할 오브젝트
    public GameObject TriggerObject;


    private bool IsAllTrue = true; //모두 true인지 확인용

    private void IsDone()
    {
        if(CheckPuzzle.Count > 0)
        {
            //모든 퍼즐이 해결되었는지 확인
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
                    Debug.Log("퍼즐의 마지막 오브젝트가 아닙니다.");
                    break;
                }
            }

            //퍼즐 해결 여부에 따른 기능 수행
            if (IsAllTrue)  //해결시
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

                //해결시 수행하는 기능
                if (TriggerObject.TryGetComponent<InteractFunction>(out var function))
                {
                    function.BasicFunction();
                }

                Destroy(this);
            }
            else            
            {
                //미해결시 수행하는 기능

            }
        }
        else
        {
            Debug.Log("해결할 퍼즐이 없습니다.");
        }
        
    }

    private void FixedUpdate()
    {
        IsDone();
    }
}
