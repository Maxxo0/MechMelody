using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClassic : MonoBehaviour
{
    [Header("Enemy References")]
    BoxCollider2D enemyCol;
    Rigidbody2D enemyRb;
    CapsuleCollider2D enemyShield;
    [SerializeField] int startingPoint;
    [SerializeField] Transform[] points;
    public int i;
    public float speed;
    

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
        enemyRb = GetComponent<Rigidbody2D>();
        enemyShield = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (enemyHealth <= 0) { gameObject.SetActive(false); }
    }


    void Move()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //sumar 1 al indice.Al cambiar el indice,cambia el objetivo a seguir
            if (i == points.Length) //chequea si el valor de i es igual a la longitud del Array
            {
                i = 0; // si lo es, el indice pasa a ser  0 para repetir la ruta

            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        /*
        transform.rotation = Quaternion.Euler(0, 180, 0);
        distance = Vector2.Distance(transform.position, Player.transform.position) ;
        transform.position = Vector2.MoveTowards(this.transform.position, points[i].position, speedboost * Time.deltaTime);*/
        if (i == 1) { transform.rotation = Quaternion.Euler(0, 180, 0); }
        if (i == 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem hpSystem = collision.gameObject.GetComponent<HealthSystem>();
            hpSystem.TakeDamage(damage);
            collision.rigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (GameManager.Instance.actualMusicStatus == GameManager.MusicStatus.blue)
            {

                enemyHealth -= takeDamage;
                collision.gameObject.SetActive(false);
            }
            else
            {
                collision.gameObject.SetActive(false);
            }

        }
    }

    
}
