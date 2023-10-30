using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float flySpeed = 5;

    public float yawAmount = 120;

    private float yaw;
    private float pitch;
    private float roll;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position += transform.forward * (flySpeed * Time.deltaTime);
        yaw += yawAmount * x * Time.deltaTime;
        pitch = Mathf.Lerp(0, 30, Mathf.Abs(y)) * Mathf.Sign(y);
        roll
            = Mathf.Lerp(0, 30, Mathf.Abs(x)) * -Mathf.Sign(x);
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + 
                                                   Vector3.right * pitch + Vector3.forward * roll);
    }
}
