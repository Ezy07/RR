using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    //Field
    #region .

    public float CloseInteractionRayLength = 20f;
    public float WeaponInteractionRayLength = 50f;

    public bool OnLight = false;

    #endregion

    //Method
    #region .

    void TryCloseInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, CloseInteractionRayLength))
        {
            //���̰� �浹�� ���� �ڵ�
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                targetfunction.CloseInteract();
            }
        }
    }

    void TryWeaponInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, WeaponInteractionRayLength))
        {
            //���̰� �浹�� ���� �ڵ�
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                if (targetfunction.InteractableTarget)
                {
                    targetfunction.WeaponInteract();
                }
            }
        }
    }

    #endregion

    //Unity Event
    #region .

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //EŰ�� �̿��� ��ȣ�ۿ�
        {
            TryCloseInteract();
        }
        else if (Input.GetMouseButtonDown(0) && OnLight) // ��Ŭ�� + ���� �Ʒ��� ���� �ÿ�
        {
            TryWeaponInteract();
        }
        else if (Input.GetMouseButton(0)) // �׽�Ʈ ��
        {
            TryWeaponInteract();
        }
    }

    #endregion

}
