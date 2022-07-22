using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public Camera MainCamera;
    private void Awake()
    {
        ResumeGame();
    }
    // Update is called once per frame
    void Update()
    {
        MainCamera = Camera.main;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                ResumeGame();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Pause();

            }
        }
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
 
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
