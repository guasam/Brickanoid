using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody rb;
    private Vector3 direction = new Vector3(1, 0, 1);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Change velocity based on reflection for current direction
        rb.velocity = Vector3.Reflect(direction * speed, collision.GetContact(0).normal);

        // Set new velocity direction
        direction = rb.velocity.normalized;
    }
}