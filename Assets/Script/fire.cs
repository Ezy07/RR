using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject Bullet; //�߻��ϴ� �Ѿ�
    public Transform FirePos; //�߻��ϴ� ��ġ

<<<<<<< HEAD
=======
    public void Fire()
    {
        Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
    }

>>>>>>> Summer
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(Input.GetMouseButtonDown (0))
        {
            //�߻�ü ����
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation); ;
        }
        //�����Ӹ��� �߻�ü �߻�
        transform.Translate(Vector3.forward * 0.5f);    
=======

>>>>>>> Summer
    }
}
