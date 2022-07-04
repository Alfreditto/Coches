using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    //[HideInInspector]
    [Range(0, 90), SerializeField, Tooltip("Velocidad actual del coche")]
    private float speed, aceleration = 0.03f, maxSpeed = 50.0f;

    [Range(0, 100), SerializeField, Tooltip("Velocidad de giro del coche")]
    public float turnSpeed = 50f;

    private float horizontalInput, verticalInput;

    [SerializeField] private GameObject carretera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        ConprobarSiEstaEnLaCarretera();
        Acelerar();

        AcelerarAtras();
        if (verticalInput is 0)
        {
            PonerEnReposo();
        }

        //movemos el coche adelante
        // S = V*T
        transform.Translate(Vector3.forward * (speed * Time.deltaTime)); //0,0,1

        //girar
        if (speed is not 0)
        {
            transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));
        }
    }

    private void ConprobarSiEstaEnLaCarretera()
    {
        if (transform.position.y - carretera.transform.position.y is >= 10 or <= -10)
        {
            transform.position = new Vector3(-4, 1, -9);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            speed = 0;
        }
    }

    private void PonerEnReposo()
    {
        if (speed is < 0.1f and > -0.1f)
        {
            speed = 0;
        }

        if (verticalInput == 0 && speed > 0)
        {
            speed -= 0.01f;
        }
        else if (verticalInput == 0 && speed < 0)
        {
            speed += 0.01f;
        }
    }

    private void AcelerarAtras()
    {
        if (verticalInput < 0 && speed > -maxSpeed)
        {
            if (speed < 0)
            {
                speed -= aceleration;
            }
            else
            {
                speed -= aceleration * 3;
            }
        }
    }

    private void Acelerar()
    {
        if (verticalInput > 0 && speed < maxSpeed)
        {
            if (speed > 0)
            {
                speed += aceleration;
            }
            else
            {
                speed += aceleration * 3;
            }
        }
    }
}