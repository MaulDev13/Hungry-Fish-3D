using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;

    PlayerCollider stat;

    private void Start()
    {
        stat = GetComponent<PlayerCollider>();
    }

    void Update()
    {
        if (stat.IsDead)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * movementSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * movementSpeed * Time.deltaTime, Space.World);
        }
    }
}
