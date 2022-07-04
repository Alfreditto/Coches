using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    //[HideInInspector]
    [Range(0, 90), SerializeField, Tooltip("Velocidad actual del coche")]
    private float speed = 15.0f, aceleration = 0 , maxSpeed = 90.0f, minSpeed = 0.0f;

    [Range(0, 100), SerializeField, Tooltip("Velocidad de giro del coche")]
    public float turnSpeed = 50f;

    private float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //movemos el coche adelante
        // S = V*T
        transform.Translate(Vector3.forward * (speed * Time.deltaTime * verticalInput)); //0,0,1

        //girar
        transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));
    }
}