using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class AirBlock : InteractFunction
{
    public float MinX, MaxX;

    public XRController controller = null;

    public override void BasicFunction()
    {
        throw new System.NotImplementedException();
    }

    public override void ToolMainInteract()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButton))
        {
            while (triggerButton)
            {
                transform.localPosition += new Vector3(1f, 0f, 0f) * Time.deltaTime;
            }
        }
    }

    public override void ToolSubInteract()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
        {
            while(AButton)
            {
                transform.localPosition -= new Vector3(1f, 0f, 0f) * Time.deltaTime;
            }
        }
        
    }

    public void ConstraintPosition()
    {
        Vector3 CurPos = transform.localPosition;

        CurPos.x = Mathf.Clamp(CurPos.x, MinX, MaxX);
        CurPos.y = Mathf.Clamp(CurPos.y, CurPos.y, CurPos.y);
        CurPos.z = Mathf.Clamp(CurPos.z, CurPos.z, CurPos.z);

        transform.localPosition = CurPos;
    }

    private void Start()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        ConstraintPosition();
    }
}
