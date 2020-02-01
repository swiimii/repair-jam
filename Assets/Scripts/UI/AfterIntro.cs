using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterIntro : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Go to the first scene
        Debug.Log("QUIT");
        Application.Quit();
    }
}
