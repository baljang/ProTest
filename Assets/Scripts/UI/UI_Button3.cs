using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button3 : MonoBehaviour
{
    public void OnButtonClicked()
    {
        //    Managers.Scene.LoadScene(Define.Scene.Scene3);
        StartCoroutine(LoadMyAsyncScene(Define.Scene.Scene3));
    }

    IEnumerator LoadMyAsyncScene(Define.Scene type)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(GetSceneName(type));

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }
}
