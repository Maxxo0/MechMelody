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
    [SerializeField] GameObject musicPanel;
    

    [Header("Move Stats")]
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public int nJumps;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashTime;
    [SerializeField] bool canMove;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        isGrounded = true;
        nJumps = 1;
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        if (moveInput.x > 0) { jumpForce = 5f; }
        if (moveInput.x < 0) { jumpForce = 5f; }
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
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
      
        switch(GameManager.Instance.actualMusicStatus)
        {
            case GameManager.MusicStatus.purple:
                if (isGrounded && context.started)
                {
                    Salto();

                    //playerAnimator.SetBool("Jump", true);
                }
                else 
                {
                    if (!isGrounded && nJumps > 0 && context.started )
                    {
                        Salto();
                        nJumps--;
                    }
                }
                break;
            case GameManager.MusicStatus.yellow:
                if (isGrounded && context.started)
                {
                    Salto();

                    //playerAnimator.SetBool("Jump", true);
                }
                else
                {
                    if (!isGrounded && context.started)
                    {
                        Planeo();
                    }
                }
                break;
            case GameManager.MusicStatus.orange:
                if (isGrounded && moveInput.x == 0 && context.started)
                {
                    jumpForce = 20f;
                    Salto();

                    //playerAnimator.SetBool("Jump", true);
                }
                else if (isGrounded && context.started)
                {
                    Salto();
                }
                break;
            case GameManager.MusicStatus.blue:
                if (isGrounded && context.started)
                {
                    Salto();
                }
                else if (!isGrounded && context.started)
                {
                    Debug.Log("kms");
                    StartCoroutine(Dash());
                }

                break;
        }

    }

     public void ChangeMusic(InputAction.CallbackContext context)
     {
        playerInput.SwitchCurrentActionMap("MusicMenu");
        musicPanel.SetActive(true);

     }
     
    public void ReturnGameplay(InputAction.CallbackContext context) 
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
        musicPanel.SetActive(false);
    }
    

    void Salto()
    {
        isGrounded = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Planeo()
    {
        rb.gravityScale = 0.5f;
    }

 


    private IEnumerator Dash()
    {
        Debug.Log("va");
        canMove = false;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(dashForce * moveInput.x, 0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1f;
        canMove = true;
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            nJumps = 1;
            rb.gravityScale = 1f;
            
        }
    }
}

