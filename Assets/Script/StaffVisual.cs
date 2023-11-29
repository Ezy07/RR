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

    //Effect
    public List<GameObject> ParticleSystemList;

    //Method
    /// <summary>
    /// ����� ���� Material�� ����
    /// </summary>
    public void ChangeVisual()
    {
        //���� ��� ����
        int cnt = PlayerState.instance.PlayerStageCounter;
        ParticleSystemList[cnt].SetActive(false);

        cnt++;

        //���� ��� �߰�
        for (int i = 0; i < CrystalRenderers.Count; i++)
        {
            CrystalRenderers[i].material = MaterialList[cnt];

        }
        ParticleSystemList[cnt].SetActive(true);
        PlayerState.instance.PlayerStageCounter = cnt;
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
