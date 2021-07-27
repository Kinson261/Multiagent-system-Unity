using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour
{
    public float speed;
    Rigidbody ourPlane;

    void Start()
    {
        ourPlane = GetComponent<Rigidbody>();
        speed = 100.0f;
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        //Rigidbody.MovePosition(Rigidbody.position + transform.forward * Time.deltaTime * speed);

        speed -= transform.forward.y * Time.deltaTime * 20.0f;

        if (speed < 50.0f)
        {
            speed = 50.0f;
        }


        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        //float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        //if (terrainHeightWhereWeAre > transform.position.y + 50.0f)
        //{
        //    transform.position = new Vector3(transform.position.x,
        //                                    terrainHeightWhereWeAre,
        //                                     transform.position.z);
        //}


        SpeedUpDown();
    }



    void SpeedUpDown()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed += 5;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed -= 5;
        }
    }


}
