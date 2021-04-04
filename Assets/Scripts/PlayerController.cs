using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float maxPosX = 5.25f;

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Clamp the position so the player cannot move beyond walls
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxPosX, maxPosX), 0, 0);
    }
}
