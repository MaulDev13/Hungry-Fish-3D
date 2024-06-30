using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public float sensitivity = 0.5f;
    public Vector2 turn;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        turn.x = turn.x % 360f;
        turn.y = turn.y % 360f;

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0f);
    }
}
