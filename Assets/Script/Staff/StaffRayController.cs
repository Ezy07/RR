using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StaffRayController : MonoBehaviour
{
    [SerializeField]
    private LayerMask InteractableLayer;

    private LineRenderer rayLineRenderer;
    private StaffFunction staffFunction;

    // Start is called before the first frame update
    void Start()
    {
        rayLineRenderer = GetComponent<LineRenderer>();
        staffFunction = GetComponentInParent<StaffFunction>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new(transform.position, transform.forward);   //Ray �߻� ���� �� ����

        float rayLength;    //���� ���� �ǽð� �ݿ�
        if (PlayerState.instance.PlayerIsOnLight) { rayLength = staffFunction.OnLightRayDistance; }
        else { rayLength = staffFunction.ToolInteractionRayLength; }

        rayLineRenderer.SetPosition(1, new Vector3(0, 0, rayLength));   //LineRenderer ���� �ݿ�

        if (Physics.Raycast(ray, rayLength, InteractableLayer))
        {
            rayLineRenderer.startColor = Color.white;
            rayLineRenderer.endColor = Color.white;
        }
        else
        {
            rayLineRenderer.startColor = Color.red;
            rayLineRenderer.endColor = Color.red;
        }
    }
}
