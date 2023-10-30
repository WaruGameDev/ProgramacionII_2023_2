
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speedCar = 60;
    public float maxSpeed = 80;
    public float drag = .985f;
    public float steerAngle = 120;
    public float traction = 1;
    public Transform body;
    public float bodyTilt = 30;
    public Vector3 moveForce;
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        moveForce += transform.forward * (y * speedCar * Time.deltaTime);
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        moveForce *= drag;
        transform.position += moveForce * Time.deltaTime;
        transform.Rotate(Vector3.up * (moveForce.magnitude * x * 
                                       steerAngle * Time.deltaTime));
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, 
                        traction * Time.deltaTime) *
                    moveForce.magnitude;
        float roll = Mathf.Lerp(0, bodyTilt, Mathf.Abs(x)) * Mathf.Sign(x);
        if (moveForce.magnitude > 0)
        {
            body.localRotation = Quaternion.Euler
                (Vector3.forward * roll);
        }
        
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        Debug.DrawRay(transform.position, moveForce.normalized * 3, Color.red);
        
    }
}
