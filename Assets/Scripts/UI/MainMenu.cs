using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        //SceneManager.LoadScene("");  // Uncomment this line and add the first scene
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
