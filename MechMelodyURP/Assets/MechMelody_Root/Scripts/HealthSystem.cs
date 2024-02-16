using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Image hpBar;
    public float health;
    public float maxHealth;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { health = 0; Die(); }
        hpBar.fillAmount = health / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Damage");
    }

    void Die()
    {
        SceneManager.LoadScene((gameObject.scene.name));
    }
}
