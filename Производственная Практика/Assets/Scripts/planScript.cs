using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planScript : MonoBehaviour
{
    public GameObject plan;

    [Space]
    [Space]
    //Scale multiplier
    public int scaleX;
    public int scaleY;
    public int scaleZ;

    [Space]
    [Space]
    //limits  ||   Center of plan is (0,0,0)
    public float boundX;        //X is defined (-boundX, boundX)
    public float boundY;        //Y is defined (-boundY, boundY)
    public float boundZ;        //Z is defined (-boundZ, boundZ)

    public float surfacePlane;  //surface area of the plan


    // Start is called before the first frame update
    public void Start()
    {
        //init
        plan.transform.position = new Vector3(0, 0, 0);
        plan.transform.localScale = new Vector3(10, 10, 10);

        calculateSurfacePlane();
        calculateBoundaries();
    }

    // Update is called once per frame
    public void Update()
    {
        plan.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);       //tranform by user value
        calculateSurfacePlane();
        calculateBoundaries();
    }

    //A cube prefab is 1x1x1; During editing, we could insert 10 cubes in a plan.
    //This is why we multiply the user value by 10.
    public void calculateSurfacePlane()
    {
        surfacePlane = (plan.transform.localScale.x * 10f) * (plan.transform.localScale.z * 10f);
    }


    public void calculateBoundaries()
    {
        boundX = (plan.transform.localScale.x * 10f) / 2f;
        boundY = (plan.transform.localScale.y * 10f) / 2f;
        boundZ = (plan.transform.localScale.z * 10f) / 2f;
    }
}
