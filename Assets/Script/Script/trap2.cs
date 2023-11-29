using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public GameObject LiWeapon;
    public GameObject WaWeapon;
    public GameObject WiWeapon;
    public GameObject SnWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponCon WeaponCon = other.GetComponent<WeaponCon>();

        //������ ������ �� ����
        if (WeaponCon)
        {
            LiWeapon.SetActive(false);
            WaWeapon.SetActive(false);
            WiWeapon.SetActive(false);
            SnWeapon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}