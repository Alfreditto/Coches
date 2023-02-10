using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Coche_Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(car.GetComponent<CarController>().Speed, 0, 0);
    }
}