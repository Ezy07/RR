using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    //Field
    #region .

    public static KeyFunction instance;

    public bool OnLight = false;

    [SerializeField]
    private float CloseInteractionRayLength = 1f;
    [SerializeField]
    private float ToolInteractionRayLength = 2f;
    [SerializeField]
    private float OnLightRayDistance = 10f;

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
            //���̰� �浹�� ���� �ڵ�
            GameObject target = hit.collider.gameObject;
            if (target.TryGetComponent<InteractFunction>(out var targetfunction))
            {
                targetfunction.WeaponInteract();
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //EŰ�� �̿��� ��ȣ�ۿ�
        {
            TryCloseInteract();
        }
        else if (Input.GetMouseButtonDown(0)) //���콺 ��Ŭ���� �̿��� ��ȣ�ۿ�
        {
            TryWeaponInteract();
        }
    }

    #endregion

}
