using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float sensitivity = 20f;
    public Camera view;

    private Vector3 angle;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        angle.x = -Camera.main.transform.eulerAngles.x;
        angle.y = this.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        angle.x += sensitivity * x * Time.deltaTime;
        angle.y += sensitivity * y * Time.deltaTime;

        if (angle.y > 90) { angle.y = 90; }
        else if (angle.y < -90) { angle.y = -90; }

        this.transform.localEulerAngles = new Vector3(0, angle.x, 0);
        view.transform.eulerAngles = new Vector3(-angle.y, angle.x, angle.z);
    }
}
