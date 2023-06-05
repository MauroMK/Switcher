using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    #region InputManager
    private PlayerInput playerMovementInput;
    private string moveAction = "Move";
    private string jumpAction = "Jump";
    private float horizontal;
    #endregion

    private Rigidbody2D playerRb;
    private Animator anim;

    private bool isJumping;


    void Start()
    {
        playerMovementInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
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
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (horizontal < 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
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
                playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
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
        }
    }
}