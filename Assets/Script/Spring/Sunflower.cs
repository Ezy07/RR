using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    public float rotationAmount = 90f; //1회 회전량
    public float rotationSpeed = 30f; //회전 속도
    public float RayDistance = 20f; //반사 사거리
    public GameObject RayStart; //레이 발사 지점 (+X축으로)

    private bool isRotating = false;
    #endregion

    //Override Method
    #region .

    //기본 기능
    public override void BasicFunction()
    {
        Vector3 RayPos = RayStart.transform.position;
        Vector3 RayDir = RayStart.transform.forward;

        Ray beam = new(RayPos, RayDir);
        if (Physics.Raycast(beam, out RaycastHit hit, RayDistance)) //Ray 발사
        {
            GameObject target = hit.collider.gameObject;
            if (target.CompareTag("Sunflower")) //해바라기
            {
                if (target.TryGetComponent<Sunflower>(out var targetfunction))
                {
                    targetfunction.BasicFunction();
                }
            }
            else if (target.CompareTag("Zeolite"))  //비석
            {
                if (target.TryGetComponent<Zeolite>(out var targetfunction))
                {
                    targetfunction.BasicFunction();
                }
            }
        }
    }
    //무기 공격 기능
    public override void WeaponInteract()
    {
        //빛 위에 있을 경우의 좌클릭 기능
        if (KeyFunction.instance.OnLight && StartTarget) //빛 위에 있으면
        {
            BasicFunction();
        }
        //일반적인 좌클릭 기능 (회전)
        else
        {
            if (!isRotating)
            {
                RotateObject();
            }
        }
    }
    //없음
    public override void EndFunction()
    {
        throw new System.NotImplementedException();
    }
    //없음
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    //Method
    #region .
    private void RotateObject()
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
