using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Go to the first scene
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);  // UGo to the credits scene
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
