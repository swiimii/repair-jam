using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimateText : MonoBehaviour
{
    public RectTransform text;
    public RectTransform canvas;

    private float beginY;
    private float endY;

    // Start is called before the first frame update
    void Start()
    {
        beginY = 0 - canvas.rect.height / 2.5f;
        endY = 0 + canvas.rect.height * 1.5f;

        Vector3 posY = new Vector3(text.position.x, beginY, 0);

        text.position = posY;
    }

    void FixedUpdate()
    {
        text.position += (Input.GetMouseButton(0) ? 6 : 1) * Vector3.up;

        if (text.position.y >= endY)
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(3);  // Go to the first scene
    }
}
