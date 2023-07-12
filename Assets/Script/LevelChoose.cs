using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelChoose : MonoBehaviour
{
    public int LevelUnlock;
    public Button[] LevelButton;
    public void Start()
    {
        LevelUnlock = PlayerPrefs.GetInt("LevelUnlock", 1);
        for (int i = 0; i < LevelButton.Length; i++)
        {
            LevelButton[i].interactable = false;
        }

        for (int i = 0; i < LevelUnlock; i++)
        {
            LevelButton[i].interactable = true;
        }

    }
    private void Update()
    {
        
    }
    public void getButName(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
