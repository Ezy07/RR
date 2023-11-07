using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //이동속도
    public float spd = 2f;
    
    //이동방향 계산 변수
    private float x, z;

    // Update is called once per frame
    void Update()
    {
        //WASD 입력
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //방향벡터 계산
        Vector3 dir = new Vector3(x, 0, z).normalized;

        //이동
        transform.Translate(spd * Time.deltaTime * dir);
    }
}
