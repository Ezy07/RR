using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Method
    #region .
    public void StartGameSetting()
    {
        if (!instance)
        {
            instance = this;
        }
        Cursor.visible = false;
    }

    #endregion

    //Unity Event
    #region .
    private void Awake()
    {
        StartGameSetting();
        DontDestroyOnLoad(instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion
}
