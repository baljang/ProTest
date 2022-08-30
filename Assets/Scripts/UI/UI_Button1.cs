using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button1 : MonoBehaviour
{
    public void OnButtonClicked()
    {
        Managers.Scene.LoadScene(Define.Scene.Scene1);
    }
}
