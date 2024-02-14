using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shoot : MonoBehaviour
{
    [Header("Attack References")]
    [SerializeField] GameObject shootPoint; // Ref a la posición de instancia de la bala
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;
    [SerializeField] GameObject bullet4;



    [Header("Attack Stats")]
    public int condicion = 1;
    public float fireRate = 0.5f;
    public bool canShoot;
    
    




    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {

        




        switch (GameManager.Instance.actualMusicStatus) 
        {

            case GameManager.MusicStatus.purple:
                if(canShoot)
                {
                    canShoot = false;
                    Instantiate(bullet1, shootPoint.transform.position, Quaternion.identity);
                    Invoke(nameof(RestartShoot), fireRate);
                }
                break;
            case GameManager.MusicStatus.yellow:
                if (canShoot)
                {
                    canShoot = false;
                    Instantiate(bullet2, shootPoint.transform.position, shootPoint.transform.rotation);
                    Invoke(nameof(RestartShoot), fireRate);
                }
                break;
            case GameManager.MusicStatus.orange:
                if (canShoot)
                {
                    canShoot = false;
                    Instantiate(bullet3, shootPoint.transform.position, shootPoint.transform.rotation);
                    Invoke(nameof(RestartShoot), fireRate);
                }
                break;
            case GameManager.MusicStatus.blue:
                if (canShoot)
                {
                    float angle1 = 5f;
                    float angle2 = 2f;
                    float angle3 = -2f;
                    float angle4 = -5f;

                    Vector2 dir1 = CalculateVector(angle1);
                    Vector2 dir2 = CalculateVector(angle2);
                    Vector2 dir3 = CalculateVector(angle3);
                    Vector2 dir4 = CalculateVector(angle4);

                    GameObject b1 = Instantiate(bullet4, shootPoint.transform.position, shootPoint.transform.rotation);
                    b1.GetComponent<Bullet>().dir = transform.localScale.x;
                    b1.GetComponent<Bullet>().direction = dir1;
                    GameObject b2 = Instantiate(bullet4, shootPoint.transform.position, shootPoint.transform.rotation);
                    b2.GetComponent<Bullet>().dir = transform.localScale.x;
                    b2.GetComponent<Bullet>().direction = dir2;
                    GameObject b3 = Instantiate(bullet4, shootPoint.transform.position, shootPoint.transform.rotation);
                    b3.GetComponent<Bullet>().dir = transform.localScale.x;
                    b3.GetComponent<Bullet>().direction = dir3;
                    GameObject b4 = Instantiate(bullet4, shootPoint.transform.position, shootPoint.transform.rotation);
                    b4.GetComponent<Bullet>().dir = transform.localScale.x;
                    b4.GetComponent<Bullet>().direction = dir4;
                    canShoot = false;
                    Invoke(nameof(RestartShoot), fireRate);

                    
                }
                break;
        }
    }

    void RestartShoot()
    {
        canShoot = true;
    }

    Vector2 CalculateVector(float angle)
    {
        var rad = Mathf.Sin((angle * Mathf.PI) / 180);
        float Y1 = Mathf.Sin(rad);
        float X1 = Mathf.Sqrt(1 - (Y1 * Y1));

        Debug.Log(new Vector2(X1, Y1));

        return new Vector2(X1, Y1);
    }

}
