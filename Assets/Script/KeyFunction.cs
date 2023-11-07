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
            //레이가 충돌시 수행 코드
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
            //레이가 충돌시 수행 코드
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //E키를 이용한 상호작용
        {
            TryCloseInteract();
        }
        else if (Input.GetMouseButtonDown(0) && OnLight) // 좌클릭 + 빛의 아래에 있을 시에
        {
            TryWeaponInteract();
        }
        else if (Input.GetMouseButton(0)) // 테스트 용
        {
            TryWeaponInteract();
        }
    }

    #endregion

}
