using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    public float rotationAmount = 90f;
    public float rotationSpeed = 30f;
    public float RayDistance = 20f; // 반사 사거리
    public GameObject RayStart; // 레이 발사 지점

    private bool isRotating = false;
    #endregion

    //Override Method
    #region .

    //없음
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }

    //무기 공격 기능
    public override void WeaponInteract()
    {
        Vector3 RayPos = RayStart.transform.position;
        Vector3 RayDir = RayStart.transform.forward;

        Ray beam = new(RayPos, RayDir);

        if (Physics.Raycast(beam, out RaycastHit hit, RayDistance))
        {
            GameObject target = hit.collider.gameObject;
            if (target.CompareTag("Sunflower"))
            {
                if (target.TryGetComponent<InteractFunction>(out var targetfunction))
                {
                    targetfunction.WeaponInteract();
                }
            }
            else if (target.CompareTag("Zeolite"))
            {
                if (target.TryGetComponent<InteractFunction>(out var targetfunction))
                {
                    targetfunction.EndInteract();
                }
            }
        }
    }

    //없음
    public override void EndInteract()
    {
        throw new System.NotImplementedException();
    }

    #endregion

    //Method
    #region .
    void RotateObject()
    {
        float currentRotation = transform.eulerAngles.y;
        float targetRotation = currentRotation + rotationAmount;

        // 현재 각도와 목표 각도가 다른 경우에만 회전 시작
        if (!Mathf.Approximately(Mathf.Repeat(currentRotation, 360f), Mathf.Repeat(targetRotation, 360f)))
        {
            isRotating = true;
            StartCoroutine(RotateCoroutine(targetRotation));
        }
    }

    System.Collections.IEnumerator RotateCoroutine(float targetRotation)
    {
        while (!Mathf.Approximately(Mathf.Repeat(transform.eulerAngles.y, 360f), Mathf.Repeat(targetRotation, 360f)))
        {
            // 보간된 회전값 계산
            float newRotation = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation, rotationSpeed * Time.deltaTime);

            // 회전 적용
            transform.eulerAngles = new Vector3(0, newRotation, 0);

            yield return null;
        }

        // 회전이 완료된 후에 플래그를 false로 설정
        isRotating = false;
    }

    #endregion
}
