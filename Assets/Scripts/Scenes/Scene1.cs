using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : BaseScene
{ 
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Scene1; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Scene2);
        }
    }

    public override void Clear()
    {
        Debug.Log("Scene1 Clear!");
    }

}
