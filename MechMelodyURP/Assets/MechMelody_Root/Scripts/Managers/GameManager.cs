using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("GameManager is null!");
            }
            return instance;
        }
    }

    public enum MusicStatus { purple, yellow, orange, blue }

    public MusicStatus actualMusicStatus = MusicStatus.purple;

    public bool bulletRot;

    public bool isMenu;

    [SerializeField] GameObject controlMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (isMenu) 
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlayGame()
    {
        
        Time.timeScale = 1f;
        isMenu = false;
        SceneManager.LoadScene(1);
    }

    public void PlayGame(InputAction.CallbackContext context)
    {

        Time.timeScale = 1f;
        isMenu = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit(); // Cerrar juego
    }

    public void QuitGame(InputAction.CallbackContext context)
    {
        Application.Quit(); // Cerrar juego
    }

    public void Controls()
    {
        controlMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Controls(InputAction.CallbackContext context)
    {
        controlMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ExitControls()
    {
        controlMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ExitControls(InputAction.CallbackContext context)
    {
        controlMenu.SetActive(false);
        Time.timeScale = 0f;
    }



}
