using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject panel;
    public GameObject options;
    void Start()
    {
        panel.SetActive(false);
        options.SetActive(false);
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (isPaused)
        {
            //Cursor.lockState = CursorLockMode.None;

        }
        //else Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeButton()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("menu");
    }
    public void OptionsButton()
    {
        panel.SetActive(false);
        options.SetActive(true);
    }
    public void Quiting()
    {
        Application.Quit();
    }
    public void Options_resume()
    {
        options.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
}