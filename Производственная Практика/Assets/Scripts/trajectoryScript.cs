using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectoryScript : MonoBehaviour
{

    [Space]
    [Space]
    public GameObject currentSelection;

    [Space]
    [Space]
    public int i;

    [Space]
    [Space]
    public float deltaXPlane;
    public float deltaZPlane;

    [Space]
    [Space]
    public float deltaXDrone;
    public float deltaZDrone;

    [Space]
    [Space]
    public Vector3 setPositionPlane;
    public Vector3 setPositionDrone;

    [Space]
    [Space]
    public moveRobot moveRobot;
    

    // Start is called before the first frame update
    void Start()
    {
        moveRobot = GetComponent<moveRobot>();              //add gameobject to grab script
        setPositionPlane = new Vector3(100, 50, 100);          //init
        setPositionDrone = new Vector3(100, 50, 100);          //init
    }

    // Update is called once per frame
    void Update()
    {
        currentSelection = GetComponent<selectionHandler>().currentSelection ;

        if (currentSelection.tag == "Plane")
        {
            for (i = 0; i<100; i++)
            {
                if (currentSelection.transform.position != setPositionPlane)
                {
                    moveRobot.movePlane(currentSelection, setPositionPlane);
                }
                else
                {
                    int segment = i % 4;

                    if (segment == 0)
                    {
                        setPositionPlane = new Vector3(setPositionPlane.x, setPositionPlane.y, setPositionPlane.z +deltaZPlane);
                    }
                    if (segment == 1)
                    {
                        setPositionPlane = new Vector3(setPositionPlane.x + deltaXPlane, setPositionPlane.y, setPositionPlane.z);
                    }
                    if (segment == 2)
                    {
                        setPositionPlane = new Vector3(setPositionPlane.x, setPositionPlane.y, setPositionPlane.z - deltaZPlane);
                    }
                    if (segment == 3)
                    {
                        setPositionPlane = new Vector3(setPositionPlane.x + deltaXPlane, setPositionPlane.y, setPositionPlane.z + deltaZPlane);
                    }
                    i++;

                }
            }
            
        }

        if (currentSelection.tag == "Drone")
        {
            for (i=0; i < 100; i++)
            {
                if (currentSelection.transform.position != setPositionDrone)
                {
                    moveRobot.moveDrone(currentSelection,setPositionDrone);
                }
                else
                {
                    int segment = i % 4;

                    if (segment == 0)
                    {
                        setPositionDrone = new Vector3(setPositionDrone.x, setPositionDrone.y, setPositionDrone.z + deltaZDrone);
                    }
                    if (segment == 1)
                    {
                        setPositionDrone = new Vector3(setPositionDrone.x + deltaXDrone, setPositionDrone.y, setPositionDrone.z);
                    }
                    if (segment == 2)
                    {
                        setPositionDrone = new Vector3(setPositionDrone.x, setPositionDrone.y, setPositionDrone.z - deltaZDrone);
                    }
                    if (segment == 3)
                    {
                        setPositionDrone = new Vector3(setPositionDrone.x + deltaXDrone, setPositionDrone.y, setPositionDrone.z + deltaZDrone);
                    }
                    i++;

                }
            }
        }
    }
}
