using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ambienceAudio;
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] public AudioSource horrorAudio;
    [SerializeField] public AudioSource cashAudio;


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