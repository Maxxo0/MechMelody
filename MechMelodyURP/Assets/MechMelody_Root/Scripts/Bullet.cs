using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    public bool isGrounded;
    public float bulletJumpForce = 5;
    public float lifeTime;
    public float dir;
    public Vector2 direction;
    private float normalization;
    private Vector2 normalizedOrientation;
    Rigidbody2D bullet;
    bool blue;
    bool anim;    


    // Start is called before the first frame update
    void Start()
    {

        Quaternion shootPointR = GameObject.Find("ShootPoint").transform.rotation;
        transform.rotation = shootPointR;
        isGrounded = true;
        normalization = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        normalizedOrientation = new Vector3(direction.x / normalization, direction.y / normalization);
        bullet = GetComponent<Rigidbody2D>();
        
        anim = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.bulletRot == true) { dir = -1; }
        BulletStatus();
        if (bulletJumpForce <= 0) { gameObject.SetActive(false); }
        Debug.Log(dir);
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if (blue) { bullet.velocity = new Vector3(dir * bulletSpeed * normalizedOrientation.x, bulletSpeed * normalizedOrientation.y, 0); }
       
    }

    public void BulletStatus()
    {
        switch (GameManager.Instance.actualMusicStatus)
        {

            case GameManager.MusicStatus.purple:
                
                bulletSpeed = 7f;
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
                if (lifeTime <= 0) { gameObject.SetActive(false); }
                break;
            case GameManager.MusicStatus.yellow:
                
                Animator jazzAnim = GetComponent<Animator>();
                bulletSpeed = 5f;
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
                if (isGrounded)
                {
                    if (anim) { jazzAnim.SetTrigger("Ground"); }
                    
                    bullet.AddForce(Vector2.up * bulletJumpForce, ForceMode2D.Impulse);
                    isGrounded = false;
                }
                
                if (lifeTime <= 0) { gameObject.SetActive(false); }

                break;
            case GameManager.MusicStatus.orange:
                
                bulletSpeed = 50f;
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
                if (lifeTime <= 0) { gameObject.SetActive(false); }
                break;
            case GameManager.MusicStatus.blue:

                if (GameManager.Instance.bulletRot == true) { dir = -1; }
                if (GameManager.Instance.bulletRot == false) { dir = 1; }
                bulletSpeed = 30f;
                blue = true;
                if (lifeTime <= 0) { gameObject.SetActive(false); }
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bulletJumpForce--;
            isGrounded = true;
            anim = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            gameObject.SetActive(false);
        }

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

            gameObject.SetActive(false);
        }
        
    }

}
