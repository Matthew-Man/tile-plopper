using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker : MonoBehaviour
{
    public float lookSensitivity = 10f;

    private float leftRightAngle = 0;
    private float upDownAngle = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float hInput = Input.GetAxis("Mouse X") * lookSensitivity;
        float vInput = -Input.GetAxis("Mouse Y") * lookSensitivity;
        leftRightAngle += hInput;
        upDownAngle += vInput;
        upDownAngle = Mathf.Clamp(upDownAngle, -60, 60);

        transform.rotation = Quaternion.Euler(upDownAngle, leftRightAngle, 0);
    }

}