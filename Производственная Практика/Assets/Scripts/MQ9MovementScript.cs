using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQ9MovementScript : MonoBehaviour
{
    public float AmbientSpeed = 200f;
    private int speedChange = 200;

    private int RotationSpeed = 100;

    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        UpdateFunction();
    }

    void UpdateFunction()
    {
 
        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;

        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = -Input.GetAxis("Vertical") * (Time.deltaTime * RotationSpeed);
        yaw = Input.GetAxis("Horizontal") * (Time.deltaTime * RotationSpeed);

        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        m_rigidbody.transform.rotation *= AddRot;

        Vector3 AddPos = Vector3.forward;
        AddPos = m_rigidbody.rotation * AddPos;

        m_rigidbody.velocity = AddPos * (Time.deltaTime * AmbientSpeed);


    }
}
