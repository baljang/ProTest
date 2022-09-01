using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : BaseScene
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()
    {
        if (SceneManager.GetActiveScene().name.CompareTo("Scene1") != 0)
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Scene1; 
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
        Debug.Log("Scene1 Clear!");
    }

}
