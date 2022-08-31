using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{

    enum Buttons
    {
        PointButton,
        PointButton2,
    }

    enum Texts
    {
        PointText, 
        ScoreText
    }

    enum GameObjects
    {
        TestObject,
        HPBar,
        MPBar,
    }

    enum Images
    {
        ItemIcon, 
    }
     
     void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects)); 
        Bind<Image>(typeof(Images));


        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
        GetButton((int)Buttons.PointButton2).gameObject.AddUIEvent(OnButtonClicked2); 

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    int _score = 100;
    bool chanHP_plus = false; 
    bool chanHP_minus = false;
    float preRatio = 1; 
    public void OnButtonClicked(PointerEventData data)
    {
        _score = Mathf.Clamp(_score + 10, 0, 100);
        chanHP_plus = true; 

        GetText((int)Texts.ScoreText).text = $"HP : {_score}";
    }

    public void OnButtonClicked2(PointerEventData data)
    {
        _score = Mathf.Clamp(_score - 10, 0, 100);
        chanHP_minus = true;

        GetText((int)Texts.ScoreText).text = $"HP : {_score}";
    }

    void Update()
    {
        if (chanHP_plus)
        {
            float ratio = _score / 100.0f;
            ratio = Mathf.Lerp(preRatio, ratio, 10.0f * Time.deltaTime);
            if (ratio > 0.98) ratio = 1;
            SetHpRatio(ratio);
            if(Mathf.Abs(ratio - preRatio) > 0.001)
                chanHP_plus = false;
            preRatio = ratio;            
        }
        if(chanHP_minus)
        {
            float ratio = _score / 100.0f;
            ratio = Mathf.Lerp(preRatio, ratio, 10.0f * Time.deltaTime);
            SetHpRatio(ratio);
            if (Mathf.Abs(ratio - preRatio) > 0.001)
                chanHP_plus = false;
            preRatio = ratio; 
        }

    }

    public void SetHpRatio(float ratio)
    {
        GameObject go = Get<GameObject>((int)GameObjects.HPBar).gameObject;
        go.GetComponent<Slider>().value = ratio;

        GameObject go2 = Get<GameObject>((int)GameObjects.MPBar).gameObject;
        go2.GetComponent<Slider>().value = ratio;
    }
}
