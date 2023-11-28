using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    //Method
    private void RemoveMeshComponents()
    {
        // MeshFilter ������Ʈ ����
        if (TryGetComponent<MeshFilter>(out var meshFilter))
        {
            Destroy(meshFilter);
        }

        // MeshRenderer ������Ʈ ����
        if (TryGetComponent<MeshRenderer>(out var meshRenderer))
        {
            Destroy(meshRenderer);
        }
    }

    //Unity Event
    private void Start()
    {
        // MeshFilter �� MeshRenderer ������Ʈ ����
        RemoveMeshComponents();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            StaffVisual.instance.ChangeVisual();
            Destroy(gameObject);
        }
    }
}
