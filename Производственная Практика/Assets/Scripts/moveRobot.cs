using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRobot : MonoBehaviour
{

    public float speedPlane;
    public float speedDrone;

    public Rigidbody rb;
    public RaycastHit hit;
    public int height;

    public void movePlane(GameObject plane, Vector3 destination)
    {
        plane.transform.position = Vector3.MoveTowards(transform.position, destination, speedPlane*Time.deltaTime);
        plane.transform.LookAt(destination);
    }


    public void moveDrone(GameObject drone, Vector3 destination)
    {
        Vector3 pos = transform.position;
   
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position)+height;
        drone.transform.position = pos;

        destination.y = pos.y;
        drone.transform.position = Vector3.MoveTowards(pos, destination, speedDrone * Time.deltaTime);
        drone.transform.LookAt(destination);
    }

    public void Update()
    {
        rb = GetComponent<selectionHandler>().currentSelection.GetComponent<Rigidbody>();
    }
}
