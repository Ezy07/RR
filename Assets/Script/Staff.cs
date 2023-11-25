using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Staff : MonoBehaviour
{
    //Field
    #region .

    public static Staff instance;
    public Transform RayStart;

    public bool OnLight = false;

    //Setting
    [SerializeField]
    private float ToolInteractionRayLength = 2f;
    [SerializeField]
    private float OnLightRayDistance = 10f;

    #endregion

    //Method
    #region .
    public void MainInteraction()
    {
        Ray ray = new(RayStart.position, RayStart.forward);

        float RayLength;

        if (OnLight)
        {
            RayLength = OnLightRayDistance;
        }
        else
        {
            RayLength = ToolInteractionRayLength;
        }

        if (Physics.Raycast(ray, out RaycastHit hit, RayLength))
        {
            //레이가 충돌시 수행 코드
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                targetfunction.ToolMainInteract();
            }
        }
    }

    #endregion

    //Unity Event
    #region .

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

}
