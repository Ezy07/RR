using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : InteractFunction
{
    //Field
    #region .

    public float turnSpeed = 20f;
    public float RayDistance = 20f;
    public GameObject RayStart;

    private Vector3 curRotation;
    private int count;
    private bool turning = false;

    #endregion

    //Override Method
    #region .
    
    //해바라기 바라보는 방향 변경 ( Ray 방향 변경 )
    public override void CloseInteract()
    {
        if (!turning)
        {
            Debug.Log("Turning");
            count++;
        }
    }

    //무기 공격 기능
    public override void WeaponInteract()
    {
        Vector3 RayPos = RayStart.transform.position;
        Vector3 RayDir = RayStart.transform.forward;

        Ray beam = new(RayPos, RayDir);

        if (Physics.Raycast(beam, out RaycastHit hit, RayDistance))
        {
            GameObject target = hit.collider.gameObject;
            if (target.CompareTag("Sunflower"))
            {
                if (target.TryGetComponent<InteractFunction>(out var targetfunction))
                {
                    targetfunction.WeaponInteract();
                }
            }
            else if (target.CompareTag("Zeolite"))
            {
                if (target.TryGetComponent<InteractFunction>(out var targetfunction))
                {
                    targetfunction.EndInteract();
                }
            }
        }
    }

    //없음
    public override void EndInteract()
    {
        throw new System.NotImplementedException();
    }

    #endregion

    //Unity Event
    #region .
    private void Start()
    {
        curRotation = transform.eulerAngles;
        count = (int)(curRotation.y / 90) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5)
        {
            if (curRotation.y < (count - 1) * 90) { curRotation.y += turnSpeed * Time.deltaTime; turning = true; }
            else { count = 1; curRotation.y = 0; turning = false; }
        }
        else if (count < 5)
        {
            if (curRotation.y < (count - 1) * 90) { curRotation.y += turnSpeed * Time.deltaTime; turning = true; }
            else { turning = false; }
        }

        //오브젝트 회전
        transform.eulerAngles = curRotation;
    }

    #endregion

}
