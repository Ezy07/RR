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


    //LineRenderer
    private LineRenderer Beam;

    //Controller ForceGrab
    [Header("Int",order = 2)]
    private int isGrab = -1;

    //Setting
    [Header("Float", order = 3)]
    public float BeamDuration = 1.0f;
    [SerializeField]
    private float ToolInteractionRayLength = 2f;
    [SerializeField]
    private float OnLightRayDistance = 10f;
    

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

        if (Physics.Raycast(ray, out RaycastHit hit, RayLength))
        {
            //봄 전용
            if(PlayerState.instance.PlayerStageCounter == 0)
            {
                //빔 이펙트
                Beam.SetPosition(1, hit.point);

                //빔 활성화
                StartCoroutine(BeamController());
            }

            //레이가 충돌시 수행 코드
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                //기능
                targetfunction.ToolMainInteract();
            }
        }
    }

    public void SubInteraction()
    {
        Ray ray = new(RayStart.position, RayStart.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, ToolInteractionRayLength))
        {
            //레이가 충돌시 수행 코드
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                targetfunction.ToolSubInteract();
            }
        }
    }

    public void WhichControllerForceGrab()
    {
        ControllerState Controller = ControllerState.instance;
        if (isGrab < 0)
        {
            if (Controller.isLeftControllerHovering)
            {
                Controller.Linteractor.useForceGrab = true;
                isGrab = 0;
            }
            else if (Controller.isRightContorllerHovering)
            {
                Controller.Rinteractor.useForceGrab = true;
                isGrab = 1;
            }
        }
        else
        {
            if (isGrab == 0)
            {
                Controller.Linteractor.useForceGrab = false;
            }
            else if (isGrab == 1)
            {
                Controller.Rinteractor.useForceGrab= false;
            }
            isGrab = -1;
        }
    }

    //Unity Event
    private void Start()
    {
        Beam = this.GetComponent<LineRenderer>();
    }
}
