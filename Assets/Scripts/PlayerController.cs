using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isDashing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isDashing = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isDashing ? dashSpeed : moveSpeed;
        rb.linearVelocity = moveInput * currentSpeed;
    }

    public void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    public void OnDash(InputValue inputValue)
    {
        isDashing = inputValue.isPressed;
    }
}
