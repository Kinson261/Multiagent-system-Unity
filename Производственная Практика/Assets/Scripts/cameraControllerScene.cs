using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraControllerScene : MonoBehaviour
{
    public float cameraSpeed;                   //Multiplier for camera Speed
    public float cameraRotatingSpeed;           //Multiplier for camera rotating speed
    

    //parameters for zooming in and out
    private float minFOV;                   //minimum Field Of View
    private float maxFOV;                   //maximum Field Of View
    private float FOV;                      //Field Of View
    public float sensitivity;

    /*[Space]
    [Space]
    public Text xText;
    public Text zText;*/

    private void Start()
    {
        //init
        minFOV = 15f;
        maxFOV = 90f;
        FOV = Camera.main.fieldOfView;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))                //Right Mouse Button
        {
            Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * cameraSpeed, 0, Input.GetAxis("Mouse Y") * cameraSpeed);

        }

        if (Input.GetMouseButton(2))                //Scroll Mouse button
        {
            Camera.main.transform.eulerAngles -= new Vector3(-Input.GetAxis("Mouse Y") * cameraRotatingSpeed, Input.GetAxis("Mouse X") * cameraRotatingSpeed, 0);

        }

        
        FOV -= (Input.GetAxis("Mouse ScrollWheel") * sensitivity);
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);             //clamping value between minFOV and maxFOV
        Camera.main.fieldOfView = FOV;

        /*xText.text = " X: " + Camera.main.transform.position.x.ToString();
        zText.text = " Z: " + Camera.main.transform.position.z.ToString();*/

    }

}
