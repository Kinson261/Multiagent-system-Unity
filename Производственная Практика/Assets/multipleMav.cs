using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multipleMav : MonoBehaviour
{

    private GameObject ObjectToDuplicate;
    public int Number = getSliderValue.SliderGet;
    
    private int i;
    
    public void Start()
    {
        ObjectToDuplicate = GameObject.Find("ObjectToDuplicate");
        for (int i = 1; i <= Number; i++)
        {
            Debug.Log("i: " + i);
            Instantiate(ObjectToDuplicate, new Vector3(i * 20.0F, i * 20.0F, i * 20.0F), Quaternion.identity);
        }
    }

    public void Update()
    {
        Debug.Log("Number: " + Number);
    }

}
