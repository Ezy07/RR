using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class StaffFunction : MonoBehaviour
{
    //Field
    [Header("Transform",order = 1)]
    [SerializeField]
    private Transform RayStart;
    [SerializeField]
    private Transform BeamPos;

    [SerializeField]
    private LayerMask InteractableLayer;

    //LineRenderer
    private LineRenderer Beam;

    //Setting
    [Header("Float", order = 3)]
    public float BeamDuration = 1.0f;
    public float ToolInteractionRayLength = 2f;
    public float OnLightRayDistance = 10f;
    

    //Method

    private IEnumerator BeamController()
    {
        Beam.enabled = true;
        yield return new WaitForSeconds(BeamDuration);
        Beam.enabled = false;
    }

    public void MainInteraction()
    {
        Ray ray = new(RayStart.position, RayStart.forward);

        float RayLength;
        if (PlayerState.instance.PlayerIsOnLight)
        {
            RayLength = OnLightRayDistance;
        }
        else
        {
            RayLength = ToolInteractionRayLength;
        }
        

        if (Physics.Raycast(ray, out RaycastHit hit, RayLength,InteractableLayer))
        {

            //레이가 충돌시 수행 코드
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                //기능
                targetfunction.ToolMainInteract();

                //봄 전용
                if (PlayerState.instance.PlayerStageCounter == 0)
                {
                    //빔 이펙트
                    Beam.SetPosition(1, hit.point);
                    //빔 활성화
                    StartCoroutine(BeamController());
                }
            }
        }
    }

    //Unity Event
    private void Start()
    {
        Beam = this.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        Beam.SetPosition(0, BeamPos.position);
    }
}
