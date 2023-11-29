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

    private bool IsMoving = false;
    [SerializeField]
    private int currentPositionIndex = 0; // ���� ��ġ�� �ε���
    public bool IsMoveForward = true;

    //Settings
    [SerializeField]
    private LayerMask layerMask;

    //Method
    private IEnumerator MoveToNextPosition()
    {
        // movements ����Ʈ�� ���� ��ġ�� �ִ��� Ȯ��
        if (movements.Count > 0)
        {
            if (IsMoveForward && currentPositionIndex + 1 < movements.Count)
            {
                Vector3 targetPos = new(movements[currentPositionIndex + 1], transform.localPosition.y, transform.localPosition.z);
                if (!IsObstacleInDirection(targetPos, RayPos.right))
                {
                    IsMoving = true; SoundManager.instance.soundList[1].Play();

                    // ���� �ε巴�� �̵���Ű�� �ڵ� (��: 1�� ����)
                    float elapsedTime = 0f;
                    float moveTime = 1f;

                    while (elapsedTime < moveTime)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new(movements[currentPositionIndex + 1], transform.localPosition.y, transform.localPosition.z), elapsedTime / moveTime);
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }
                    // �̵��� �Ϸ�� �� ���� �̵��� ��ġ�� ����
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

                    // ���� �ε巴�� �̵���Ű�� �ڵ� (��: 1�� ����)
                    float elapsedTime = 0f;
                    float moveTime = 1f;

                    while (elapsedTime < moveTime)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new(movements[currentPositionIndex - 1], transform.localPosition.y, transform.localPosition.z), elapsedTime / moveTime);
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }
                    // �̵��� �Ϸ�� �� ���� �̵��� ��ġ�� ����
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
        // ���� ��ġ���� ���� �������� Ray�� ���� ��ü�� �ִ��� Ȯ��
        if (Physics.Raycast(transform.position, dir, Vector3.Distance(transform.localPosition, targetPosition), layerMask))
        {
            // Ray�� ��ü�� ������ ��ֹ��� ����
            Debug.Log("Obstacle detected in the path");
            return true;
        }
        else
        {
            // ��ֹ��� ����
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
