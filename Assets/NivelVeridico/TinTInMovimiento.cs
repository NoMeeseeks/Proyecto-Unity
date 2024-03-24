using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinTIn : MonoBehaviour
{
    public float speed = 2f;
    public float jump = 3;
    Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("run", false);
        }
        if (Input.GetKey("space") && VerificarSuelo.isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            animator.SetBool("run", false);
        }
    }
}
