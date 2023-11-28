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
            //�� ����
            if(PlayerState.instance.PlayerStageCounter == 0)
            {
                //�� ����Ʈ
                Beam.SetPosition(1, hit.point);

                //�� Ȱ��ȭ
                StartCoroutine(BeamController());
            }

            //���̰� �浹�� ���� �ڵ�
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                //���
                targetfunction.ToolMainInteract();
            }
        }
    }

    public void SubInteraction()
    {
        Ray ray = new(RayStart.position, RayStart.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, ToolInteractionRayLength))
        {
            //���̰� �浹�� ���� �ڵ�
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
