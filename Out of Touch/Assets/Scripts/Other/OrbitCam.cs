using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCam : MonoBehaviour

{
    public Transform centerObject;
    public Vector3 axis = Vector3.up;
    public float radius = 10f;
    public float rotationSpeed = 20f;

    void Start()
    {
        transform.position = (transform.position - centerObject.position).normalized * radius + centerObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerObject.position, axis, rotationSpeed * Time.deltaTime);
        Vector3 desiredPosition = (transform.position - centerObject.position).normalized * radius + centerObject.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);
    }
}
