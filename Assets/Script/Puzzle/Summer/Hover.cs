using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    //Field
    #region .

    public float hoverHeight = 1.0f;   // 물체가 움직이는 높이
    public float hoverSpeed = 2.0f;    // 호버 속도

    private Vector3 initialPosition;    // 초기 위치

    #endregion

    //Method
    #region .

    void Hovering()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight; // Sin 함수를 사용하여 호버 효과 구현
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    #endregion

    //Unity Event
    #region .
    private void Start()
    {
        initialPosition = transform.position; // 초기 위치 설정
    }

    private void Update()
    {
        Hovering();
    }

    #endregion
}
