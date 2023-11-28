using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject Bullet; //발사하는 총알
    public Transform FirePos; //발사하는 위치

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
