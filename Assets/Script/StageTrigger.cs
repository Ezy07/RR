using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public GameObject StageClearObject;

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

    private IEnumerator PlayerToNextStage()
    {
        //스태프 비주얼 변경
        StaffVisual.instance.ChangeVisual();

        //스테이지 클리어 빔 활성화
        if(StageClearObject.TryGetComponent<LineRenderer>(out var lineRenderer))
        {
            lineRenderer.enabled = true;
        }

        //기능 수행 후 제거
        Destroy(gameObject);
        yield return null;
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
            StartCoroutine(PlayerToNextStage());
        }
    }
}
