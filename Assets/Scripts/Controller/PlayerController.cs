using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked; 
        Managers.Input.MouseAction += OnMouseClicked;

    }

    void Update()
    {
        
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit; 
        if(Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Button")))
        {
            Debug.Log("Button clicked!");
        }
    }
}
