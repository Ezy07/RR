using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCon : MonoBehaviour
{
    //���� ��� ����
    enum WeaponMode
    {
        Light,
        Water,
        wind,
        snow
    }
    WeaponMode wMode;

    // ���� ��� ����
    public GameObject LiWeapon;
    public GameObject Waeapon;
    public GameObject WiWeapon;
    public GameObject SnWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //���� �⺻ ��带 �� ���� ����
        wMode = WeaponMode.Light;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
