using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public GameObject StageClearObject;

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

    private IEnumerator PlayerToNextStage()
    {
        //������ ���־� ����
        StaffVisual.instance.ChangeVisual();

        //�������� Ŭ���� �� Ȱ��ȭ
        if(StageClearObject.TryGetComponent<LineRenderer>(out var lineRenderer))
        {
            lineRenderer.enabled = true;
        }

        //��� ���� �� ����
        Destroy(gameObject);
        yield return null;
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
            StartCoroutine(PlayerToNextStage());
        }
    }
}
