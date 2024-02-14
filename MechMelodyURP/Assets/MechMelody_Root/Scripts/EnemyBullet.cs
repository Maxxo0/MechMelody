using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float bulletSpeed;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        EBullet();
    }

    public void EBullet()
    {
        transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem hpSystem = collision.gameObject.GetComponent<HealthSystem>();
            hpSystem.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
