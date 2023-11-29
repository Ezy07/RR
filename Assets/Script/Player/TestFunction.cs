using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFunction : MonoBehaviour
{
    public float NormalLength = 3.0f, OnLightLength = 10f;

    public void MainInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        float RayLength;
        if (PlayerState.instance.PlayerIsOnLight)
        {
            RayLength = OnLightLength;
        }
        else
        {
            RayLength = NormalLength;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MainInteraction();
        }
    }
}
