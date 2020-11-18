using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip roar;
    public AudioSource audio;

    // Update is called once per frame
    private void playSound(AudioClip sound, bool loop)
    {
        audio.clip = sound;
        audio.loop = loop;
        audio.Play();
    }

    private void stopSound(AudioClip sound)
    {
        audio.clip = sound;
        audio.loop = false;
        audio.Stop();
    }

    public void playRoarSound()
    {
        playSound(roar, false);
    }

}
