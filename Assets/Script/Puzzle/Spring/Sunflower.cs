using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    //Function
    public float rotationAmount = 90f; //1ȸ ȸ����
    public float rotationSpeed = 30f; //ȸ�� �ӵ�
    public float RayDistance = 10f; //�ݻ� ��Ÿ�

    //Ray
    public Transform BeamStart; //���� �߻� ���� (+X������)
    public float RayDuration = 3.0f;
    private LineRenderer BeamLineRenderer;
    private bool isRaying = false;

    //Effect
    public ParticleSystem OnLightParticle;

    //Check
    private bool isRotating = false;
    #endregion

    //Override Method
    #region .

    //�⺻ ���
    public override void BasicFunction()
    {
        //���� �ݻ簡 ������ �߻����� �ʵ���
        if (!isRaying)
        {
            Transform rayTransform = BeamStart;

            Ray beam = new(rayTransform.position, rayTransform.TransformDirection(Vector3.forward));
            BeamLineRenderer.SetPosition(0, BeamStart.position);

            if (Physics.Raycast(beam, out RaycastHit hit, RayDistance)) //Ray �߻�
            {
                GameObject target = hit.collider.gameObject;
                Debug.Log(hit.point);
                if (target.CompareTag("Sunflower")) //�عٶ��
                {
                    if (target.TryGetComponent<Sunflower>(out var targetfunction))
                    {
                        BeamLineRenderer.SetPosition(1, hit.point);
                        targetfunction.BasicFunction();
                    }
                }
                else if (target.CompareTag("Zeolite"))  //��
                {
                    if (target.TryGetComponent<Zeolite>(out var targetfunction))
                    {
                        BeamLineRenderer.SetPosition(1, hit.point);
                        targetfunction.BasicFunction();
                    }
                }
                else
                {
                    //Ÿ���� �ƴ� ���
                    BeamLineRenderer.SetPosition(1, rayTransform.position + (rayTransform.forward * RayDistance));
                }
                StartCoroutine(BeamController());
            }
        }
    }

    //���� ���� ���
    public override void ToolMainInteract()
    {
        if (!isRotating && !isRaying)
        {
            if (PlayerState.instance.PlayerIsOnLight && IsStartTarget) //�� ���� ������
            {
                BasicFunction();
            }
            //�Ϲ����� ��Ŭ�� ��� (ȸ��)
            else
            {
                RotateObject();
            }
        }
        //�� ���� ���� ����� ��Ŭ�� ���
        
    }

    //����
    public override void ToolSubInteract()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    //Method
    #region .

    private IEnumerator BeamController()
    {
        BeamLineRenderer.enabled = true; isRaying = true;
        yield return new WaitForSeconds(RayDuration);
        BeamLineRenderer.enabled = false; isRaying = false;
    }

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

    private void Start()
    {
        BeamLineRenderer = this.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (IsStartTarget && PlayerState.instance.PlayerIsOnLight)
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
