using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    public float rotationAmount = 90f; //1ȸ ȸ����
    public float rotationSpeed = 30f; //ȸ�� �ӵ�
    public float RayDistance = 20f; //�ݻ� ��Ÿ�

    public GameObject RayStart; //���� �߻� ���� (+X������)
    public ParticleSystem OnLightParticle;

    private bool isRotating = false;
    #endregion

    //Override Method
    #region .

    //�⺻ ���
    public override void BasicFunction()
    {
        Vector3 RayPos = RayStart.transform.position;
        Vector3 RayDir = RayStart.transform.forward;

        Ray beam = new(RayPos, RayDir);
        if (Physics.Raycast(beam, out RaycastHit hit, RayDistance)) //Ray �߻�
        {
            GameObject target = hit.collider.gameObject;
            if (target.CompareTag("Sunflower")) //�عٶ��
            {
                if (target.TryGetComponent<Sunflower>(out var targetfunction))
                {
                    targetfunction.BasicFunction();
                }
            }
            else if (target.CompareTag("Zeolite"))  //��
            {
                if (target.TryGetComponent<Zeolite>(out var targetfunction))
                {
                    targetfunction.BasicFunction();
                }
            }
            else
            {
                //Ÿ���� �ƴ� ���
            }
        }
    }
    //���� ���� ���
    public override void ToolMainInteract()
    {
        //�� ���� ���� ����� ��Ŭ�� ���
        if (KeyFunction.instance.OnLight && IsStartTarget) //�� ���� ������
        {
            BasicFunction();
        }
        //�Ϲ����� ��Ŭ�� ��� (ȸ��)
        else
        {
            if (!isRotating)
            {
                RotateObject();
            }
        }
    }

    //����
    public override void ToolSubInteract()
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

    //Unity Event
    #region .

    private void FixedUpdate()
    {
        if (IsStartTarget && KeyFunction.instance.OnLight)
        {
            if (!OnLightParticle.isPlaying)
            {
                OnLightParticle.Play();
            }
        }
        else
        {
            OnLightParticle.Stop();
        }
    }

    #endregion
}
