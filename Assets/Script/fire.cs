using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject Bullet; //�߻��ϴ� �Ѿ�
    public Transform FirePos; //�߻��ϴ� ��ġ

    public void Fire()
    {
        Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
