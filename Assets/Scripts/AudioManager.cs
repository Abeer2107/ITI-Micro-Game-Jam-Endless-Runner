using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    //Clips
    public AudioClip MainMenuClip, GameplayClip, SlideClip, JumpClip, HitClip;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void playMainMenu()
    { //Main music
        GetComponent<AudioSource>().clip = MainMenuClip;
        GetComponent<AudioSource>().Play();
    }

    public void playGameplay()
    { //gameplay music
        GetComponent<AudioSource>().clip = GameplayClip;
        GetComponent<AudioSource>().Play();
    }

    public void toggleMusic()
    {
        if (GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Pause();
        else
            GetComponent<AudioSource>().Play();
    }

    public void playSlideSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = SlideClip;
        s.Play();
        Destroy(s, SlideClip.length);
    }

    public void playJumpSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = JumpClip;
        s.Play();
        Destroy(s, JumpClip.length);
    }

    public void playHitSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = HitClip;
        s.Play();
        Destroy(s, HitClip.length);
    }
}
