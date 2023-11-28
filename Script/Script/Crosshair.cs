using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float offset = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseCursorPos = Input.mousePosition; 
        mouseCursorPos.z = offset;
        transform.position = mouseCursorPos;
    }
}
