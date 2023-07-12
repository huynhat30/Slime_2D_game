using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FinishLevel : MonoBehaviour
{
    private bool LevelComplete = false;
    public LevelController lvlStatus;
    private string nameM;
    

    [SerializeField] private AudioSource finishSound;
    [SerializeField] private GameObject CompletBoard;
    [SerializeField] private GameObject NotCompletBoard;
    [SerializeField] private LevelController getPoint;
    // Start is called before the first frame update
    void Start()
    {
        nameM = SceneManager.GetActiveScene().name;
        
        CompletBoard.SetActive(false);
        NotCompletBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime") && (getPoint.getActualPoint() == getPoint.getTotalPoint()))
        {
            finishSound.Play();
            LevelComplete = true;
            lvlStatus.setMapName(nameM);
            lvlStatus.setStatus(LevelComplete);
            CompleteLevel();
            Pass();
            Debug.Log("This is lvl" + nameM + " " + getPoint.getTotalPoint() + " " + getPoint.getActualPoint());

        }
        else if (collision.gameObject.CompareTag("Slime") && (getPoint.getActualPoint() != getPoint.getTotalPoint())) {
            finishSound.Play();
            LevelComplete = false;
            NotCompleteLevel();
            Debug.Log("This is lvl" + nameM + " " + getPoint.getTotalPoint() + " " + getPoint.getActualPoint());
        }
    }

    private void CompleteLevel() {
        CompletBoard.SetActive(true);      
    }

    private void NotCompleteLevel()
    {
        NotCompletBoard.SetActive(true);
    }

    public void Continue() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Pass()
    {
        int currentLvl = SceneManager.GetActiveScene().buildIndex;
        if (currentLvl >= PlayerPrefs.GetInt("LevelUnlock"))
        {
            PlayerPrefs.SetInt("LevelUnlock", currentLvl + 1);
        }
    }

}
