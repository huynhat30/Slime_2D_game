using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;

    [SerializeField] private GameObject Instruction;

    private void Start()
    {
        isPaused = false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instruction.SetActive(false);
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

    private void Pause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void HowToPlay()
    {
        if(Instruction != null)
        {
            Instruction.SetActive(true);
        }
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    public void Back()
    {
        Instruction.SetActive(false);
    }
}
