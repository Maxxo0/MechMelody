using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicMenu : MonoBehaviour
{
    [Header("References")]
    PlayerInput playerInput;
    [SerializeField] GameObject musicPanel;
    [SerializeField] GameObject pop;
    [SerializeField] GameObject jazz;
    [SerializeField] GameObject rock;
    [SerializeField] GameObject classic;
    [SerializeField] GameObject popT;
    [SerializeField] GameObject jazzT;
    [SerializeField] GameObject rockT;
    [SerializeField] GameObject classicT;

    [Header("MusicMech")]
    int music;


    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pop.SetActive(false);
        jazz.SetActive(false);
        rock.SetActive(false);
        classic.SetActive(false);
        music = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ReturnGameplay(InputAction.CallbackContext context)
    {
        Time.timeScale = 1f;
        if (music == 1) { GameManager.Instance.actualMusicStatus = GameManager.MusicStatus.purple; }
        if (music == 2) { GameManager.Instance.actualMusicStatus = GameManager.MusicStatus.yellow; }
        if (music == 3) { GameManager.Instance.actualMusicStatus = GameManager.MusicStatus.orange; }
        if (music == 4) { GameManager.Instance.actualMusicStatus = GameManager.MusicStatus.blue; }
        musicPanel.SetActive(false);
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void Pop(InputAction.CallbackContext context)
    {
        pop.SetActive(true);
        jazz.SetActive(false);
        rock.SetActive(false);
        classic.SetActive(false);
        music = 1;
    }

    public void Jazz(InputAction.CallbackContext context) 
    {
        pop.SetActive(false);
        jazz.SetActive(true);
        rock.SetActive(false);
        classic.SetActive(false);
        music = 2;
    }

    public void Rock(InputAction.CallbackContext context)
    {
        pop.SetActive(false);
        jazz.SetActive(false);
        rock.SetActive(true);
        classic.SetActive(false);
        music = 3;
    }

    public void Classic(InputAction.CallbackContext context) 
    {
        pop.SetActive(false);
        jazz.SetActive(false);
        rock.SetActive(false);
        classic.SetActive(true);
        music = 4;
    }
}
