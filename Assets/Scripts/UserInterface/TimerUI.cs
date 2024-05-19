using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public static TimerUI instance;

    [SerializeField] private TextMeshProUGUI timeText;

    private TimeSpan timePlaying;

    private bool timerGoing;
    public float timeElapsed;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeText.text = "00:00";
        //Debug.Log(float minutes + ":" float seconds);
        timeElapsed = 0;

        timerGoing = true;
        StartCoroutine(UpdateTimerCR());
    }

    public void TimerStop()
    {
        timerGoing = false;
    }

    public IEnumerator UpdateTimerCR()
    {
        while(timerGoing)
        {
            timeElapsed += Time.deltaTime; // CHANGE TO COUNTDOWN?
            timePlaying = TimeSpan.FromSeconds(timeElapsed);
            string timePlayingStr = timePlaying.ToString("mm':'ss");
            timeText.text = timePlayingStr;

            yield return null;
        }
    }
}
