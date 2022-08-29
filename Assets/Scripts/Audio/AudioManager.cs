using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic audio manager for clips in game. To be redone as audio needs increase
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip paradoxClip;

    [SerializeField]
    AudioClip winClip;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnParadox += PlayParadoxClip;
        GameEvents.OnWin += PlayWinClip;
    }

    private void OnDisable()
    {
        GameEvents.OnParadox -= PlayParadoxClip;
        GameEvents.OnWin -= PlayWinClip;

    }

    private void PlayParadoxClip()
    {
        source.PlayOneShot(paradoxClip);
    }

    private void PlayWinClip()
    {
        source.PlayOneShot(winClip);
    }
}
