using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("= Audio Manager =")]
    [Space(10)]

    [SerializeField]
    private AudioSource ambienceAudio;

    private void Awake()
    {
        ambienceAudio = GetComponent<AudioSource>();
    }

    public void BackroundAmbience()
    {
        ambienceAudio.Play();
    }
}