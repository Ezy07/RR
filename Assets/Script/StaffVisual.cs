using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffVisual : MonoBehaviour
{
    //Field
    //instance
    public static StaffVisual instance = null;

    //Visual
    public List<MeshRenderer> CrystalRenderers;
    public List<Material> MaterialList;
    private int curOrder = 0;

    //Effect
    public List<GameObject> ParticleSystemList;

    //Method
    /// <summary>
    /// 실행시 다음 Material로 변경
    /// </summary>
    public void ChangeVisual()
    {
        ParticleSystemList[curOrder].SetActive(false);
        curOrder++;
        for (int i = 0; i < CrystalRenderers.Count; i++)
        {
            CrystalRenderers[i].material = MaterialList[curOrder];

        }
        ParticleSystemList[curOrder].SetActive(true);
    }

    //Unity Event
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
