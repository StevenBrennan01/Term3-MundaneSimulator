using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ambienceAudio;
    [SerializeField] private AudioSource musicAudio;

    private void Awake()
    {
        ambienceAudio = GetComponent<AudioSource>();
        musicAudio = GetComponent<AudioSource>();
    }

    public void BackroundAmbience()
    {
        ambienceAudio.Play();
        musicAudio.Play();
    }
}