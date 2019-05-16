using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Calculator : MonoBehaviour
{

    public InputField firstNumber;
    public InputField secondNumber;
    public Text result;
    public Dropdown dropdown;
    private double a, b;
    // Start is called before the first frame update
    void Start()
    {
        a = b = 0;
        result.text = "0";
    }

    public void Equals()
    {
        if (firstNumber.text.ToString().Length > 0 && secondNumber.text.ToString().Length > 0)
        {
            double.TryParse(firstNumber.text.ToString(), out a);
            double.TryParse(secondNumber.text.ToString(), out b);
            result.text = Calculate().ToString();
        }
        else
        {
            result.text = "Introduceti 2 numere";
        }
    }


    public double Calculate()
    {
        switch (dropdown.value)
        {
            case 0:
                {
                    return a + b;
                }
                break;
            case 1:
                {
                    return a - b;
                }
                break;
            case 2:
                {
                    return a * b;
                }
                break;
            case 3:
                {
                    return a / b;
                }
                break;
            default:
                {
                    return 0;
                }
                break;
        }
    }
}
