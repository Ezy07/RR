using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class AirBlock : InteractFunction
{
    //Field
    public List<float> movements;

    public Transform RayPos;
    public float RayDirectionDistanceOffset;

    private bool IsMoving = false;
    [SerializeField]
    private int currentPositionIndex = 0; // 현재 위치의 인덱스
    public bool IsMoveForward = true;

    //Settings
    [SerializeField]
    private LayerMask layerMask;

    //Method
    private IEnumerator MoveToNextPosition()
    {
        // movements 리스트에 다음 위치가 있는지 확인
        if (movements.Count > 0)
        {
            if (IsMoveForward && currentPositionIndex + 1 < movements.Count)
            {
                Vector3 targetPos = new(movements[currentPositionIndex + 1], transform.localPosition.y, transform.localPosition.z);
                if (!IsObstacleInDirection(targetPos, RayPos.right))
                {
                    IsMoving = true; SoundManager.instance.soundList[1].Play();

                    // 블럭을 부드럽게 이동시키는 코드 (예: 1초 동안)
                    float elapsedTime = 0f;
                    float moveTime = 1f;

                    while (elapsedTime < moveTime)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new(movements[currentPositionIndex + 1], transform.localPosition.y, transform.localPosition.z), elapsedTime / moveTime);
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }
                    // 이동이 완료된 후 다음 이동할 위치로 갱신
                    currentPositionIndex = (currentPositionIndex + 1) % movements.Count; IsMoving = false;
                }
                else
                {
                    yield return null;
                }
            }
            else if (!IsMoveForward && currentPositionIndex - 1 >= 0)
            {
                Vector3 targetPos = new(movements[currentPositionIndex - 1], transform.localPosition.y, transform.localPosition.z);
                if(!IsObstacleInDirection(targetPos, RayPos.right * -1))
                {
                    IsMoving = true; SoundManager.instance.soundList[1].Play();

                    // 블럭을 부드럽게 이동시키는 코드 (예: 1초 동안)
                    float elapsedTime = 0f;
                    float moveTime = 1f;

                    while (elapsedTime < moveTime)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new(movements[currentPositionIndex - 1], transform.localPosition.y, transform.localPosition.z), elapsedTime / moveTime);
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }
                    // 이동이 완료된 후 다음 이동할 위치로 갱신
                    currentPositionIndex = (currentPositionIndex - 1) % movements.Count; IsMoving = false;
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private bool IsObstacleInDirection(Vector3 targetPosition, Vector3 dir)
    {
        // 현재 위치에서 진행 방향으로 Ray를 쏴서 물체가 있는지 확인
        if (Physics.Raycast(RayPos.position, dir, RayDirectionDistanceOffset + 1f, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public override void BasicFunction()
    {
        
    }

    public override void ToolMainInteract()
    {
        if (!IsMoving)
        {
            StartCoroutine(MoveToNextPosition());
        }
    }
}
