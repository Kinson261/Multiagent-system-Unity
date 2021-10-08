using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectionHandler : MonoBehaviour
{
    public Dropdown dropdown;

    [Space]
    [Space]
    //create Text objects to hold current coordinates
    public Text posX;
    public Text posZ;
    public Text posY;

    public GameObject currentSelection;
    public GameObject[] objectsWithTagsDrone;               //array of GameObjects of type "Drone"
    public GameObject[] objectsWithTagsPlane;         //array of GameObjects of type "Rover"
    public int i;

    public List<GameObject> allAgents;                      //Lkst of all agents
    public List<GameObject> allDrones; 
    public List<GameObject> allPlanes;
    

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GameObject.Find("DropdownCurrentSelection").GetComponent<Dropdown>();
        dropdown.options.Clear();

        
        fillAgents();
        dropdownAgentSelected(dropdown);
        GetPosition();

        //Adds listener for changed value in the dropdown
        dropdown.onValueChanged.AddListener(delegate { dropdownAgentSelected(dropdown); });
    }


    //select GameObject of the choosen option
    public void dropdownAgentSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        currentSelection = GameObject.Find(dropdown.options[index].text);

        GetPosition();
    }

    
    //Get current position
    public void GetPosition()
    {
        posX.text = "X:" + currentSelection.transform.position.x.ToString();
        posY.text = "Y:" + currentSelection.transform.position.y.ToString();
        posZ.text = "Z:" + currentSelection.transform.position.z.ToString();
    }


    public void fillAgents()
    {

        allAgents = new List<GameObject>();
        allDrones = new List<GameObject>();
        allPlanes = new List<GameObject>();
        dropdown.options.Clear();

        allAgents.Add(GameObject.Find("None"));
        /*Add "None" as a GameObject to avoid a runtime error
         * Get position ALWAYS requires at least 1 agent;
         * if there is no agent, it creates a runtime error
         */

        //Adds drones to the list of all agents
        objectsWithTagsDrone = GameObject.FindGameObjectsWithTag("Drone");
        for (i = 0; i < objectsWithTagsDrone.Length; i++)
        {
            allAgents.Add(objectsWithTagsDrone[i]);
            allDrones.Add(objectsWithTagsDrone[i]);
        }

        //Adds rovers to the list of all agents
        objectsWithTagsPlane = GameObject.FindGameObjectsWithTag("Plane");
        for (i = 0; i < objectsWithTagsPlane.Length; i++)
        {
            allAgents.Add(objectsWithTagsPlane[i]);
            allPlanes.Add(objectsWithTagsPlane[i]);
        }

        //Fill dropdown with agents
        foreach (GameObject item in allAgents)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item.name });
        }

    }

    public void Update()
    {
        fillAgents();
        GetPosition();
    }
}
