using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getSliderValue : MonoBehaviour
{
    public int SliderGet;

    public void Start()
    {
        SliderGet = 0;
    }

    public void Update()
    {
        SliderGet = (int)GetComponent<Slider>().value;

    }

}