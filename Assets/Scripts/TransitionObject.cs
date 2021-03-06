﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionObject : MonoBehaviour
{

    public int sceneNumber = -1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            SceneManager.LoadScene(sceneNumber >= 0 ? sceneNumber : SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
