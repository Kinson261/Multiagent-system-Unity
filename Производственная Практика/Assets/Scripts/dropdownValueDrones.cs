using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class dropdownValueDrones : MonoBehaviour
{
    [Space]
    [Space]
    public planScript PlanScript;

    [Space]
    [Space]
    private GameObject[] drones = new GameObject[10];           //limit drone number to 10
    private GameObject objectToCopy;
    private GameObject objectToDestroy;

    public Dropdown m_Dropdown;
    public int m_DropdownValue;

    private int i;
    private int iMax;
    public GameObject[] NB;

    [Space]
    [Space]
    //var with random values
    private float randPosX;
    private float randPosY;
    private float randPosZ;

    // Start is called before the first frame update
    public void Start()
    {
        determineI();
        //Adds a listener to the dropdown and invokes a method when the value changes.
        m_Dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(m_Dropdown);
        });

        objectToCopy = GameObject.Find("MAV00");             //sample
        
    }


    void DropdownValueChanged(Dropdown change)
    {

        determineI();
        iMax = (int)change.value;           //new value
        Duplicate();
        Delete();
        determineI();
    }
    

    //function to generate drones
    public void Duplicate()
    {
        for (i = NB.Length; i <= iMax; i++)
        {
            //generate random numbers within the limits of the plan
            randPosX = Random.Range(-PlanScript.boundX, PlanScript.boundX);
            randPosY = Random.Range(0f, PlanScript.boundY);
            randPosZ = Random.Range(-PlanScript.boundZ, PlanScript.boundZ);


            drones[i] = Instantiate(objectToCopy);          //generate drones

            drones[i].transform.position = new Vector3(randPosX, randPosY, randPosZ);

            drones[i].transform.rotation = Quaternion.identity;
            drones[i].name = "MAV0" + i;

        }

    }



    //function to delete drones
    public void Delete()
    {
        for (iMax = m_Dropdown.value+1; iMax <= i; iMax++)
        {
            objectToDestroy = GameObject.Find("MAV0" + iMax.ToString());
            Destroy(objectToDestroy);
        }
    }


    //function to evaluate how many drones are on the scene
    public void determineI()
    {
        NB = GameObject.FindGameObjectsWithTag("Drone");
        i = NB.Length;
    }

    public void Update()
    {
        determineI();
        Delete();
    }
}
