using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class dropdownValuePlanes : MonoBehaviour
{
    [Space]
    [Space]
    public planScript PlanScript;

    [Space]
    [Space]
    private GameObject[] planes = new GameObject[10];               //limit rover number to 20
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
    void Start()
    {
      
        //Adds a listener to the dropdown and invokes a method when the value changes.
        m_Dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(m_Dropdown);
        });

        objectToCopy = GameObject.Find("Plane00");         //sample
        determineI();
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
            randPosY = Random.Range(0f, PlanScript.boundX);
            randPosZ = Random.Range(-PlanScript.boundZ, PlanScript.boundZ);

            
            planes[i] = GameObject.Instantiate(objectToCopy);           //generate drones
            
            planes[i].transform.position = new Vector3(randPosX, randPosY, randPosZ);
           
            planes[i].transform.rotation = Quaternion.identity;
            planes[i].name = "Plane0" + i;
            

        }

    }

    //function to delete rovers
    public void Delete()
    {
        for (iMax = m_Dropdown.value+1; iMax <= i; iMax++)
        {
            objectToDestroy = GameObject.Find("Plane0" + iMax.ToString());
            Destroy(objectToDestroy);
            //allAgents.Remove(drones[iMax]);
        }
    }

    //function to evaluate how many rovers are on the scene
    public void determineI()
    {
        NB = GameObject.FindGameObjectsWithTag("Plane");
        i = NB.Length;
    }

    public void Update()
    {
        determineI();
        Delete();
    }
}
