using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoopScript : MonoBehaviour
{
    public AudioSource source;
    public float loopStartpos;
    public float loopEndPos;

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying || loopEndPos > 0 && source.time > loopEndPos)
        {
            source.time = loopStartpos;
            source.Play();
        }
    }
}
