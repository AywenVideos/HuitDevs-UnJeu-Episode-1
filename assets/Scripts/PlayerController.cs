
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Controls { mobile,pc}

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 7f;
    public bool isSprinting = false;
    public float jumpForce = 40f;
    public float doubleJumpForce = 30f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGroundedBool;
    private bool canDoubleJump;

    public Animator playeranim;

    public Controls controlmode;
   

    private float moveX;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        if(TextBoxScript.isActive()) return;

        isGroundedBool = IsGrounded();

        if (isGroundedBool)
        {
            if (!Input.GetButton("Jump"))
            {
                canDoubleJump = false;
            }

            if (controlmode == Controls.pc)
            {
                moveX = Input.GetAxis("Horizontal");
            }


            if (Input.GetButtonDown("Jump"))
            {
                Jump(jumpForce);
                canDoubleJump = true;
            }

            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }
        else
        {
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                Jump(doubleJumpForce);
                canDoubleJump = false;
            }
        }

        SetAnimations();

        if (moveX != 0)
        {
            FlipSprite(moveX);
        }
    }
    public void SetAnimations()
    {
        if (moveX != 0 && isGroundedBool)
        {
            playeranim.SetBool("run", true);
        }
        else
        {
            playeranim.SetBool("run",false);
        }
       
    }

    private void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void FixedUpdate()
    {
        //TODO Y'a un bug qui fait que t'es bloqué partout car une force s'applique toujours, dernier dev, fix le stp j'ai pas le temps
        if(TextBoxScript.isActive()) return;

        rb.velocity = new Vector2(moveX * (isSprinting ? sprintSpeed : moveSpeed), rb.velocity.y);

        if(transform.position.y <= -330) {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector3(transform.position.x, -326);
        }
    }

    private void Jump(float jumpForce)
    {
        if(TextBoxScript.isActive()) return;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playeranim.SetTrigger("jump");
    }

    private bool IsGrounded()
    {
        float rayLength = 0.2f;
        Vector2 rayOrigin = new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y - 0.1f);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
        return hit.collider != null;
    }
}