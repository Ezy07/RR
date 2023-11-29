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
    /// 실행시 다음 Material로 변경
    /// </summary>
    public void ChangeVisual()
    {
        //기존 기능 제거
        int cnt = PlayerState.instance.PlayerStageCounter;
        ParticleSystemList[cnt].SetActive(false);

        cnt++;

        //다음 기능 추가
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
