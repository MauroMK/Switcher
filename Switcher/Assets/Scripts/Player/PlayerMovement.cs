using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 5;

    #region InputManager
    private PlayerInput playerMovementInput;
    private string moveAction = "Move";
    private string jumpAction = "Jump";
    private float horizontal;
    #endregion

    #region References
    private Rigidbody2D playerRb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    #endregion

    private bool isJumping;
    private bool isUpsideDown;
    private string yellowButtonTag = "YellowButton";

    void Start()
    {
        playerMovementInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        isUpsideDown = false;
    }

    private void FixedUpdate() 
    {
        OnMove();
    }


    void OnMove()
    {
        //TODO put into FixedUpdate
        horizontal = playerMovementInput.actions[moveAction].ReadValue<Vector2>().x;

        playerRb.velocity = new Vector2(horizontal * speed, playerRb.velocity.y);

        if (horizontal > 0f)
        {
            anim.SetBool("Run", true);
            spriteRenderer.flipX = false;
        }

        if (horizontal < 0f)
        {
            anim.SetBool("Run", true);
            spriteRenderer.flipX = true;
        }

        if (horizontal == 0f)
        {
            anim.SetBool("Run", false);
        }
    }

    public void OnJump()
    {
        bool jump = playerMovementInput.actions[jumpAction].WasPressedThisFrame();

        if (jump)
        {
            if (!isJumping)
            {
                AudioManager.instance.PlaySound("Jump");

                playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = true;
            anim.SetBool("Jump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag(yellowButtonTag))
        {
            isUpsideDown = !isUpsideDown;
            AudioManager.instance.PlaySound("GravitySwitch");
            UpdateGravity();
        }
    }

    public void UpdateGravity()
    {
        if (isUpsideDown)
        {
            playerRb.gravityScale = -4f;
            jumpForce = -5f;
            spriteRenderer.flipY = true;
            boxCollider.offset = new Vector2(0, 0.55f);
        }
        else
        {
            playerRb.gravityScale = 4f;
            jumpForce = 5f;
            spriteRenderer.flipY = false;
            boxCollider.offset = new Vector2(0, -0.55f);
        }
    }


}
