using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{
    [Header("Basic Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private Animator animator = null;
    private float moveInput;

    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask groundLayer = 0;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private bool isGrounded = false;

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
        Flip();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded && context.performed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        if (context.canceled)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    public void SpeedUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveSpeed *= 1.25f;
            jumpForce *= 1.1f;

        }
        if (context.canceled)
        {
            moveSpeed /= 1.25f;
            jumpForce /= 1.1f;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (transform.position.y < -7f)
        {
            Die();
        }
    }

    void Flip()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isRunning", true);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
