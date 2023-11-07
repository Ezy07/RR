using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //�̵��ӵ�
    public float spd = 2f;
    
    //�̵����� ��� ����
    private float x, z;

    // Update is called once per frame
    void Update()
    {
        //WASD �Է�
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //���⺤�� ���
        Vector3 dir = new Vector3(x, 0, z).normalized;

        //�̵�
        transform.Translate(spd * Time.deltaTime * dir);
    }
}
