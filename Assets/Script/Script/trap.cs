using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
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

        //함정을 지나갈 시 변경
        if (WeaponCon)
        {
            LiWeapon.SetActive(false);
            WaWeapon.SetActive(true);
            WiWeapon.SetActive(false);
            SnWeapon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
