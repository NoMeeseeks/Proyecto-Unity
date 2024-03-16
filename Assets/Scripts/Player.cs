using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //variable animacion
    public Animator anim;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    public float speed = 4f, jumpingPower = 10f;
    private bool isFacingRight = true;
    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        Correr();
    }
    public void Correr()
    {
        if (horizontal > 0f || horizontal < 0f)
        {
            anim.SetBool("run", true);
        }
        if (horizontal == 0f)
        {
            anim.SetBool("run", false);
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
