using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    [SerializeField] DynamicJoystick dynamicJoystick;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
    }

    public void JoystickMovement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector3 addedPosition = new Vector3(vertical * speed * Time.deltaTime, 0, -horizontal * speed * Time.deltaTime);
        transform.position += addedPosition;

        Vector3 direction = (Vector3.forward * vertical) + (Vector3.right * horizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
}
