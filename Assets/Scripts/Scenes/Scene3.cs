using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3 : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Scene3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit();
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public override void Clear()
    {
        Debug.Log("Scene3 Clear!");
    }
}
