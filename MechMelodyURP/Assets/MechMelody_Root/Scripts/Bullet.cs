using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    public bool isGrounded;
    public float bulletJumpForce = 5;
  
    

    // Start is called before the first frame update
    void Start()
    {
        Quaternion shootPointR = GameObject.Find("ShootPoint").transform.rotation;
        transform.rotation = shootPointR;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        BulletStatus();
        if (bulletJumpForce <= 0) { gameObject.SetActive(false); }
    }

    public void BulletStatus()
    {
        switch (GameManager.Instance.actualMusicStatus)
        {

            case GameManager.MusicStatus.purple:
                bulletSpeed = 5f;
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
                break;
            case GameManager.MusicStatus.yellow:
                Rigidbody2D yellowBullet = GetComponent<Rigidbody2D>();
                bulletSpeed = 5f;
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
                if (isGrounded)
                {
                    isGrounded = false;
                    yellowBullet.AddForce(Vector2.up * bulletJumpForce, ForceMode2D.Impulse);
                }
                
                
                break;
            case GameManager.MusicStatus.orange:
                bulletSpeed = 50f;
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bulletJumpForce--;
            isGrounded = true;
        }
    }

}
