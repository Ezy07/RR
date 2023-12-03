using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringWhenIsNotGrab : MonoBehaviour
{
    //Field
    public float hoverHeight = 0.2f;   // 물체가 움직이는 높이
    public float hoverSpeed = 0.5f;    // 호버 속도

    private Vector3 initialPosition;

    public bool IsGrab = false;

    //Mehtod
    void Hovering()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight; // Sin 함수를 사용하여 호버 효과 구현
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    public void RelocateHoverPosition()
    {
        initialPosition = transform.position;
    }

    public void StaffIsGrabbed(bool value)
    {
        IsGrab = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrab)
        {
            Hovering();
        }
    }
}
