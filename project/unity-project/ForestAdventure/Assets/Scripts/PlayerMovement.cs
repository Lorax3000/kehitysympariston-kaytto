
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player movement speed
    public float moveSpeed = 5f;

    // Gravity force
    public float gravity = -9.81f;

    // Character Controller component
    private CharacterController controller;

    // Vertical movement
    private Vector3 velocity;

    void Start()
    {
        // Get Character Controller
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get keyboard input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create movement direction
        Vector3 movement = new Vector3(
            horizontal,
            0f,
            vertical
        );

        // Prevent faster diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1f);

        // Move the player
        controller.Move(
            movement * moveSpeed * Time.deltaTime
        );

        // Apply gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
