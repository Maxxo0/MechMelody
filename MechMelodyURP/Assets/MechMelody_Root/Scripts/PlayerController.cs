using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    Rigidbody2D rb;
    CapsuleCollider2D playerCol;
    PlayerInput playerInput;
    Vector2 moveInput;
    SpriteRenderer playerSprite;
    Animator playerAnimator;


    [Header("Move Stats")]
    public float speed;
    public float jumpForce;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        
        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, 0);
        if (moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //playerAnimator.SetBool("Run", true);
        }
        else if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //playerAnimator.SetBool("Run", true);
        }
        else
        {
            //playerAnimator.SetBool("Run", false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (/*isGrounded() && */context.started)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            //playerAnimator.SetBool("Jump", true);
        }

    }

   /* public void ChangeMusic(InputAction.CallbackContext context)
    {
        GameManager.Instance.actualMusicStatus = GameManager.MusicStatus.yellow;
    }
    */

}

