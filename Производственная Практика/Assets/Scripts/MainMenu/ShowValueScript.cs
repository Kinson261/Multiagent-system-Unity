using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValueScript : MonoBehaviour
{
    public Text valueText;

    void Start()
    {
        valueText = GetComponent<Text>();

    }

    public void textUpdate(float value)
    {
        valueText.text = value + "";
    }
}
