using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip uiClickSound;
    public AudioClip transitionInSound;
    public AudioClip transitionOutSound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void PlayUIClick() => PlaySound(uiClickSound);
    public void PlayTransitionIn() => PlaySound(transitionInSound);
    public void PlayTransitionOut() => PlaySound(transitionOutSound);
}
