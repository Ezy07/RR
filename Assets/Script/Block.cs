using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : InteractFunction
{
    public override void BasicFunction()
    {
        throw new System.NotImplementedException();
    }

    public override void ToolMainInteract()
    {
        this.transform.localPosition += new Vector3(1f, 0, 0) * Time.deltaTime;
    }

    public override void ToolSubInteract()
    {
        this.transform.localPosition += new Vector3(-1f, 0, 0) * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
