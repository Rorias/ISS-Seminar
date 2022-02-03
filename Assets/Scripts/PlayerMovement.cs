using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector] public bool locked = false;

    private Animator anim;

    private SpriteRenderer spriteRend;

    public Sprite downSprite;
    public Sprite upSprite;
    public Sprite rightSprite;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!locked)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed);
                anim.SetBool("MovingUp", true);
                anim.SetBool("MovingDown", false);
                spriteRend.flipX = false;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -moveSpeed);
                anim.SetBool("MovingUp", false);
                anim.SetBool("MovingDown", true);
                spriteRend.flipX = false;
            }

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                anim.SetBool("MovingDown", false);
                anim.SetBool("MovingUp", false);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                anim.SetBool("MovingRight", true);
                spriteRend.flipX = true;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                anim.SetBool("MovingRight", true);
                spriteRend.flipX = false;
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                anim.SetBool("MovingRight", false);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
