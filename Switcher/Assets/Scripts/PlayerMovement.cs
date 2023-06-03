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
    private Animator playerAnim;


    void Start()
    {
        playerMovementInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    void OnMove()
    {
        //TODO put into FixedUpdate
        horizontal = playerMovementInput.actions[moveAction].ReadValue<Vector2>().x;

        playerRb.velocity = new Vector2(horizontal * speed, 0f);
    }

    void OnJump()
    {

    }
}
