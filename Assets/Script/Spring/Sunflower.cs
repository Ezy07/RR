using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    public float rotationAmount = 90f;
    public float rotationSpeed = 30f;
    public float RayDistance = 20f; // �ݻ� ��Ÿ�
    public GameObject RayStart; // ���� �߻� ����

    private bool isRotating = false;
    #endregion

    //Override Method
    #region .

    //����
    public override void CloseInteract()
    {
        throw new System.NotImplementedException();
    }

    //���� ���� ���
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

    //����
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

        // ���� ������ ��ǥ ������ �ٸ� ��쿡�� ȸ�� ����
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
            // ������ ȸ���� ���
            float newRotation = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation, rotationSpeed * Time.deltaTime);

            // ȸ�� ����
            transform.eulerAngles = new Vector3(0, newRotation, 0);

            yield return null;
        }

        // ȸ���� �Ϸ�� �Ŀ� �÷��׸� false�� ����
        isRotating = false;
    }

    #endregion
}
