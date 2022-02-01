using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector] public bool locked = false;

    private Animator spriteAnim;

    private SpriteRenderer spriteRend;

    public Sprite downSprite;
    public Sprite upSprite;
    public Sprite rightSprite;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!locked)
        {
<<<<<<< Updated upstream
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -moveSpeed);
            }

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
=======
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed);
            spriteRend.sprite = upSprite;
            spriteRend.flipX = false;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -moveSpeed);
            spriteRend.sprite = downSprite;
            spriteRend.flipX = false;
        }

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            spriteRend.sprite = rightSprite;
            spriteRend.flipX = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            spriteRend.sprite = rightSprite;
            spriteRend.flipX = false;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
>>>>>>> Stashed changes
        }
    }
}
