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

    private AudioSource AudioSetting;

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

            //���̰� �浹�� ���� �ڵ�
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                //���
                targetfunction.ToolMainInteract();
                AudioSetting.Play();

                //�� ����
                if (PlayerState.instance.PlayerStageCounter == 0)
                {
                    //�� ����Ʈ
                    Beam.SetPosition(1, hit.point);
                    //�� Ȱ��ȭ
                    StartCoroutine(BeamController());
                }
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

    //Unity Event
    private void Start()
    {
        Beam = this.GetComponent<LineRenderer>();
        AudioSetting = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Beam.SetPosition(0, BeamPos.position);
    }
}
