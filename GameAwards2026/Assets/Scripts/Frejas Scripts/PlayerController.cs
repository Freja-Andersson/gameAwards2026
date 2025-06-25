using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    [SerializeField] float deacceleration = 5f;
    [SerializeField] float velocityPower = 5f;
    [SerializeField] float frictionAmount = 5f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 5f;

    Vector2 movementVector;

    Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }

    void Movement()
    {
        float targetSpeed = movementVector.x * moveSpeed;
        float speedDifference = targetSpeed - playerRigidbody.linearVelocityX;
        float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deacceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDifference) * accelerationRate, velocityPower) * Mathf.Sign(speedDifference);
        playerRigidbody.AddForce(movement * Vector2.right);
    }

}
