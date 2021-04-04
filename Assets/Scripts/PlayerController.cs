using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 15f;
    private readonly float maxPosX = 5.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Handle Movement

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

        #endregion
    }
}
