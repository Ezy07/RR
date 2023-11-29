using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : InteractFunction
{
    [SerializeField]
    private AirBlock m_AirBlock;

    public override void BasicFunction()
    {
        throw new System.NotImplementedException();
    }

    public override void ToolMainInteract()
    {
        if (m_AirBlock.IsMoveForward)
        {
            m_AirBlock.IsMoveForward = false;
            this.transform.localRotation = new Quaternion(0, 180, 0, 0);
            SoundManager.instance.soundList[1].Play();
        }
        else
        {
            m_AirBlock.IsMoveForward = true;
            this.transform.localRotation = new Quaternion(0, 0, 0, 0);
            SoundManager.instance.soundList[1].Play();
        }
    }
}
