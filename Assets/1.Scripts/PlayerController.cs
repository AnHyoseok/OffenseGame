using IdleGame.Character;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleGame.Player
{

public class PlayerController : SpriteDirection
    {
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isDashing = false;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isDashing = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isDashing ? dashSpeed : moveSpeed;
        rb.linearVelocity = moveInput * currentSpeed;
        UpdateSpriteDirection();
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
    
}