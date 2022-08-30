using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2 : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Scene2; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Scene3); 
        }
    }


    public override void Clear()
    {
        Debug.Log("Scene2 Clear!"); 
    }
}
