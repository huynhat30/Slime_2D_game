using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionPage : MonoBehaviour
{
    public void BackToMenu() {
        SceneManager.LoadScene("StartScreen");
    }

    public void ToInstructionPage()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
