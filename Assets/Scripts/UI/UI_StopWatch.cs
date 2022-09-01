using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_StopWatch : UI_Base
{
    enum Buttons
    {
        StartButton,
        PauseButton,
        InitiButton,
        InputButton,
    }
    enum Texts
    {
       TimeScreen,
    }
    enum GameObjects
    {
        InputSeconds,
    }

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.InputButton).gameObject.AddUIEvent(OnButtonClicked);
        GetButton((int)Buttons.StartButton).gameObject.AddUIEvent(OnStartButtonClicked);
        GetButton((int)Buttons.PauseButton).gameObject.AddUIEvent(OnPauseButtonClicked);
        GetButton((int)Buttons.InitiButton).gameObject.AddUIEvent(OnInitiButtonClicked); 

    }

    float seconds;
    
    int hr;
    int min;
    int sec;

    string timecon;
    public void OnButtonClicked(PointerEventData data)
    {
        GameObject go = Get<GameObject>((int)GameObjects.InputSeconds).gameObject;
        seconds = int.Parse(go.GetComponent<InputField>().text);

        ShowOnDisplay();
    }

    bool _running = false; 
    public void OnStartButtonClicked(PointerEventData data)
    {
        _running = true; 
    }

    public void OnPauseButtonClicked(PointerEventData data)
    {
        _running = false; 
    }

    public void OnInitiButtonClicked(PointerEventData data)
    {
        seconds = 0;
        ShowOnDisplay();
    }

    void Update()
    {
        if (_running)
        {
            RunTimer();
            ShowOnDisplay();
        }
    }

    void RunTimer()
    {
        if (seconds  < 0.001)
        {
            seconds = 0;
            _running = false;
            return;
        }
        seconds -= Time.deltaTime; 
    }

    void ShowOnDisplay()
    {
        hr = (int)(seconds / 3600);
        min = (int)((seconds % 3600) / 60);
        sec = (int)((seconds % 3600) % 60);

        timecon = String.Format("{0:D2}:{1:D2}:{2:D2}", hr, min, sec);

        GetText((int)Texts.TimeScreen).text = timecon;
    }
}
