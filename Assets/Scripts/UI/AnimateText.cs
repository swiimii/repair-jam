using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateText : MonoBehaviour
{
    public RectTransform text;
    public RectTransform canvas;

    private float beginY;
    private float endY;

    // Start is called before the first frame update
    void Start()
    {
        beginY = 0 - canvas.rect.height / 2;
        endY = 0 + canvas.rect.height * 2;

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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Go to the first scene
        Debug.Log("QUIT");
        Application.Quit();
    }
}
