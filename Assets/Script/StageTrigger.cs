using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    //Method
    private void RemoveMeshComponents()
    {
        // MeshFilter 컴포넌트 제거
        if (TryGetComponent<MeshFilter>(out var meshFilter))
        {
            Destroy(meshFilter);
        }

        // MeshRenderer 컴포넌트 제거
        if (TryGetComponent<MeshRenderer>(out var meshRenderer))
        {
            Destroy(meshRenderer);
        }
    }

    //Unity Event
    private void Start()
    {
        // MeshFilter 및 MeshRenderer 컴포넌트 제거
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
