﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResize : MonoBehaviour
{
    public RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rect.localScale = new Vector3(0.5f, 0.5f);
    }
}
