using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SlotMachine : UI_Base
{
    public GameObject[] SlotObject;    // SlotMachinPanel/Line one, two, three/SlotObject(bundle of imageUI Objects: 0~10) 
    public Button[] Slot;           // Line one, two, three
    public Sprite[] NumberSprite;    // Image files 1~10

    [System.Serializable]
    public class DisplayNumberSlot
    {
        public List<Image> SlotSprite = new List<Image>();
    }
    public DisplayNumberSlot[] DisplayNumberSlots;    // 0~10 ImageUIObjects * 3lines

    int NumCnt = 10;        // how many numbers
    int[] answer = { 2, 3, 1 };

    Coroutine[] co = new Coroutine[3];  


    enum Buttons
    {
        SpinButton, 
        StopButton,
    }

    enum GameObjects
    {
        IndexInput, 
        SlotMachinePanel,
    }

     void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.SpinButton).gameObject.AddUIEvent(OnSpinButtonClicked);
        GetButton((int)Buttons.StopButton).gameObject.AddUIEvent(OnStopButtonClicked);

        for (int i = 0; i < Slot.Length; i++)   
        {
            for (int j = 0; j < NumCnt; j++)    
            {
                Slot[i].interactable = false;
              
                DisplayNumberSlots[i].SlotSprite[j].sprite = NumberSprite[j]; // number setting 

                if (j == 0)
                {
                    DisplayNumberSlots[i].SlotSprite[NumCnt].sprite = NumberSprite[j];   // make same first and end 
                }
            }
        }  
    }

    bool _isRunning = false;

    void OnSpinButtonClicked(PointerEventData data)
    {
        if(_isRunning)
            return;
        for (int i = 0; i < Slot.Length; i++)
        {
            co[i] = StartCoroutine(StartSlot(i));
        }
        _isRunning = true;
    }

    IEnumerator StartSlot(int SlotIndex)
    {
        for (; ; )
        {
            SlotObject[SlotIndex].transform.localPosition -= new Vector3(0, 20f, 0);   
            if (SlotObject[SlotIndex].transform.localPosition.y < 20f)
            {
                SlotObject[SlotIndex].transform.localPosition += new Vector3(0, 1000f, 0);   
            }
            yield return new WaitForSeconds(0.01f+SlotIndex*0.005f);
        }
    }

    IEnumerator IndexSlot(int SlotIndex, int NumIndex =0)
    {
        SlotObject[SlotIndex].transform.localPosition = new Vector3(0, 0, 0);
        int randomCnt = UnityEngine.Random.Range(0, NumCnt);

        for (int i = 0; i < (randomCnt * (6 + SlotIndex * 4) + answer[SlotIndex]) * 2; i++)
        {
            SlotObject[SlotIndex].transform.localPosition -= new Vector3(0, 50f, 0);   
               
            if (SlotObject[SlotIndex].transform.localPosition.y < 50f)
            {
                SlotObject[SlotIndex].transform.localPosition += new Vector3(0, 1000f, 0);  
            }
            yield return new WaitForSeconds(0.02f);
        }
        if (1 <= NumIndex && NumIndex <= 10)
        {
            SlotObject[SlotIndex].transform.localPosition = new Vector3(0, 0, 0);

            SlotObject[SlotIndex].transform.localPosition += new Vector3(0, 50f * (NumIndex - 1) * 2, 0);
        }
    }

    int _index = 0;
    void OnStopButtonClicked(PointerEventData data)
    {
        if (!_isRunning)
            return;

        GameObject go = Get<GameObject>((int)GameObjects.IndexInput).gameObject;
        string num = go.GetComponent<InputField>().text;
        if(num!="")
            _index = int.Parse(num);

        for (int i = 0; i < 3; i++)
        {
            StopCoroutine(co[i]);
            co[i] = null;
        }

        for (int i = 0; i < Slot.Length; i++)
        {
            co[i] = StartCoroutine(IndexSlot(i, _index));
        }

        _isRunning = false;
        _index = 0; 
    }

    void Update()
    {
        
    }
}
