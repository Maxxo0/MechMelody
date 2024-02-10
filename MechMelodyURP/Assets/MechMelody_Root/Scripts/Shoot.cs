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
    public float fireRate =     0.5f;
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
                    canShoot = false;
                    Instantiate(bullet4, shootPoint.transform.position, shootPoint.transform.rotation);
                    Invoke(nameof(RestartShoot), fireRate);
                }
                break;
        }
    }

    void RestartShoot()
    {
        canShoot = true;
    }

    

}
