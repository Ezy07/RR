using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    //Field
    #region .

    public float hoverHeight = 1.0f;   // ��ü�� �����̴� ����
    public float hoverSpeed = 2.0f;    // ȣ�� �ӵ�

    private Vector3 initialPosition;    // �ʱ� ��ġ

    #endregion

    //Method
    #region .

    void Hovering()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight; // Sin �Լ��� ����Ͽ� ȣ�� ȿ�� ����
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    #endregion

    //Unity Event
    #region .
    private void Start()
    {
        initialPosition = transform.position; // �ʱ� ��ġ ����
    }

    private void Update()
    {
        Hovering();
    }

    #endregion
}
