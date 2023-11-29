using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    //Function
    public float rotationAmount = 90f; //1회 회전량
    public float rotationSpeed = 30f; //회전 속도
    public float RayDistance = 10f; //반사 사거리

    //Ray
    public Transform BeamStart; //레이 발사 지점 (+X축으로)
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

    //기본 기능
    public override void BasicFunction()
    {
        //빛의 반사가 무한히 발생하지 않도록
        if (!isRaying)
        {
            Transform rayTransform = BeamStart;

            Ray beam = new(rayTransform.position, rayTransform.TransformDirection(Vector3.forward));
            BeamLineRenderer.SetPosition(0, BeamStart.position);

            if (Physics.Raycast(beam, out RaycastHit hit, RayDistance)) //Ray 발사
            {
                GameObject target = hit.collider.gameObject;
                if (target.CompareTag("Sunflower")) //해바라기
                {
                    if (target.TryGetComponent<Sunflower>(out var targetfunction))
                    {
                        BeamLineRenderer.SetPosition(1, hit.point);
                        targetfunction.BasicFunction();
                    }
                }
                else if (target.CompareTag("Zeolite"))  //비석
                {
                    if (target.TryGetComponent<Zeolite>(out var targetfunction))
                    {
                        BeamLineRenderer.SetPosition(1, hit.point);
                        targetfunction.BasicFunction();
                    }
                }
                else
                {
                    //타겟이 아닌 경우
                    BeamLineRenderer.SetPosition(1, rayTransform.position + (rayTransform.forward * RayDistance));
                }
                StartCoroutine(BeamController());
            }
            else
            {
                BeamLineRenderer.SetPosition(1, rayTransform.position + (rayTransform.forward * RayDistance));
                StartCoroutine(BeamController());
            }
        }
    }

    //무기 공격 기능
    public override void ToolMainInteract()
    {
        if (!isRotating && !isRaying)
        {
            if (PlayerState.instance.PlayerIsOnLight && IsStartTarget) //빛 위에 있으면
            {
                BasicFunction();
            }
            //일반적인 좌클릭 기능 (회전)
            else
            {
                RotateObject();
            }
        }
        //빛 위에 있을 경우의 좌클릭 기능
        
    }

    //없음
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
