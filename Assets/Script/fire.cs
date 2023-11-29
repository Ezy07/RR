using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject Bullet; //발사하는 총알
    public Transform FirePos; //발사하는 위치

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
            //발사체 복제
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation); ;
        }
        //프레임마다 발사체 발사
        transform.Translate(Vector3.forward * 0.5f);    
=======

>>>>>>> Summer
    }
}
