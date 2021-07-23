using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getSliderValue : MonoBehaviour
{
    public Slider slider;
    public int sliderValStart;
    public int sliderValEnd;

    private GameObject objectToDuplicate;
    public int diff;





    void Start()
    {
        sliderValStart = (int)GetComponent<Slider>().value;

    }

    public void OnValuechanged(int value)
    {
        System.Threading.Thread.Sleep(500);
        sliderValEnd = (int)GetComponent<Slider>().value;
        diff = sliderValEnd - sliderValStart;
        //sliderValStart = sliderValEnd;
    }

    public void Duplicate()
    {
        objectToDuplicate = GameObject.Find("Full_Mav");
        if (diff > 0)
        {
            for (int i = 0; i<diff-1; i++)
            {
                Instantiate(objectToDuplicate, new Vector3(i * 3.0F, i * 3.0F, i * 3.0F), Quaternion.identity);
            }
            
        }
    }

    public void Delete()
    {
        if (diff < 0)
        {
            objectToDuplicate = GameObject.Find("Full_Mav(clone)");
            for (int i = diff; i > 0; i--)
            {
                Destroy(objectToDuplicate, 1.0F);
            }

        }
    }

}