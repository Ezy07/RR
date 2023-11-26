using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Staff : MonoBehaviour
{
    //Field
    #region .
    public Transform RayStart;

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
            //���̰� �浹�� ���� �ڵ�
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                targetfunction.ToolMainInteract();
            }
        }
    }

    #endregion
}
