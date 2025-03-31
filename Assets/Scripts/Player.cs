using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A y D (o flechas izquierda/derecha)
        float moveZ = Input.GetAxis("Vertical");   // W y S (o flechas arriba/abajo)

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Aplicar gravedad
        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = -2f; // Evita acumulación de gravedad
        }
    }
}
