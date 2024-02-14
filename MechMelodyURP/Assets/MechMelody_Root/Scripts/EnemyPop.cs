using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPop : MonoBehaviour
{
    [Header("Enemy References")]
    BoxCollider2D enemyCol;
    CircleCollider2D shootCol;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPoint;
    public float fireRate = 1.5f;
    public bool canShoot;
    

    [Header("Enemy Damage")]
    public int damage;
    public int takeDamage;


    [Header("Enemy HP")]
    public float enemyHealth;
    public float enemyMaxHealth;    


    // Start is called before the first frame update
    void Start()
    {
        enemyCol = GetComponent<BoxCollider2D>();
        shootCol = GetComponent<CircleCollider2D>();
        canShoot = true;
        fireRate = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyHealth <= 0) { gameObject.SetActive(false); }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canShoot)
            {
                Shoot();
                Invoke(nameof(RestartShoot), fireRate);
            }
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem hpSystem = collision.gameObject.GetComponent<HealthSystem>();
            hpSystem.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(GameManager.Instance.actualMusicStatus == GameManager.MusicStatus.purple)
            {
                enemyHealth -= takeDamage;
                collision.gameObject.SetActive(false);
            }
            
        }
    }

    void Shoot()
    {
        canShoot = false;
        Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
        
    }

    void RestartShoot()
    {
        canShoot = true;
    }
}
