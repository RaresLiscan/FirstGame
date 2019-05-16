using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TestScript : MonoBehaviour
{
    public Text text;
    private string hour, minute, second;
    public Dropdown dropdown;
    public bool enable;
    // Start is called before the first frame update
    void Start() {
        enable = false;
        Size();
    }

    // Update is called once per frame
    void Update() {
        if (enable)
        {
            EnableClock();
        }
        else text.text = "Hello World!";
    }

    public void EnableClock()
    {
        DateTime date = DateTime.Now;
        hour = date.Hour.ToString();
        minute = date.Minute.ToString();
        second = date.Second.ToString();
        text.text = hour + ":" + minute + ":" + second; 
    }

    public void enableDisable ()
    {
        enable = !enable;
    }

    public void Size()
    {
        switch (dropdown.value)
        {
            case 0:
                {
                    transform.localScale = new Vector3(20f, 20f, 20f);
                }
                break;
            case 1:
                {
                    transform.localScale = new Vector3(35f, 35f, 35f);
                }
                break;
            case 2:
                {
                    transform.localScale = new Vector3(50f, 50f, 50f);
                }
                break;
            default: break;
        }
    }
}
