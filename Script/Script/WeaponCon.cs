using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCon : MonoBehaviour
{
    //무기 모드 변수
    enum WeaponMode
    {
        Light,
        Water,
        wind,
        snow
    }
    WeaponMode wMode;

    // 무기 모양 변수
    public GameObject LiWeapon;
    public GameObject Waeapon;
    public GameObject WiWeapon;
    public GameObject SnWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //무기 기본 모드를 빛 모드로 설정
        wMode = WeaponMode.Light;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
