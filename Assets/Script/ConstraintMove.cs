using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintMove : MonoBehaviour
{
    [SerializeField]
    protected float MinX, MaxX, MinY, MaxY, MinZ, MaxZ;

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.localPosition;

        float clampedX = Mathf.Clamp(curPos.x, MinX, MaxX);
        float clampedY = Mathf.Clamp(curPos.y, MinY, MaxY);
        float clampedZ = Mathf.Clamp(curPos.z, MinZ, MaxZ);

        transform.localPosition = new Vector3(clampedX, clampedY, clampedZ);
    }
}
