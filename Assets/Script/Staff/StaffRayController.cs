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
        Ray ray = new(transform.position, transform.forward);   //Ray 발사 지점 및 방향

        float rayLength;    //레이 길이 실시간 반영
        if (PlayerState.instance.PlayerIsOnLight) { rayLength = staffFunction.OnLightRayDistance; }
        else { rayLength = staffFunction.ToolInteractionRayLength; }

        rayLineRenderer.SetPosition(1, new Vector3(0, 0, rayLength));   //LineRenderer 길이 반영

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
