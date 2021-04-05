using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    float speed = 15f;
    Rigidbody rb;
    Vector3 startDirection = new Vector3(1, 0, 1);
    Vector3 direction;
    Vector3 startPos;
    bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = rb.position;
        direction = startDirection;
    }

    void Update()
    {
        if (!isMoving && Keyboard.current.spaceKey.isPressed)
        {
            rb.velocity = direction * speed;
            isMoving = true;
        }
    }

    void FixedUpdate()
    {
        // Respawn ball if goes out of bounds
        if (rb.position.z < -4f)
        {
            direction = startDirection;
            rb.position = startPos;
            rb.velocity = Vector3.zero;
            isMoving = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Change velocity based on reflection for current direction
        rb.velocity = Vector3.Reflect(direction, collision.GetContact(0).normal) * speed;

        // Set new velocity direction
        direction = rb.velocity.normalized;

        // Destroy brick on collision
        if (collision.collider.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
    }
}
