using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource BGMusic;
    [SerializeField] AudioSource SFXSource;


    [Header("--------- Audio Source ---------")]
    public AudioClip background;
    public AudioClip jumpSound;


    private void Start()
    {
        BGMusic.clip = background;
        BGMusic.loop = true;
        BGMusic.volume = 100f;
        BGMusic.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}



