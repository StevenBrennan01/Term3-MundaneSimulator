using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private static TimerUI instance;

    [SerializeField] private TextMeshProUGUI timeText;

    private TimeSpan timePlaying;

    private bool timerGoing;

    private Coroutine updateTimer_CR;

    public float timeElapsed;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeText.text = "00:00";
        timeElapsed = 0;

        timerGoing = true;
        updateTimer_CR = StartCoroutine(UpdateTimerCR());
    }

    public void TimerStop()
    {
        timerGoing = false;
    }

    IEnumerator UpdateTimerCR()
    {
        while(timerGoing)
        {
            timeElapsed += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(timeElapsed);
            string timePlayingStr = timePlaying.ToString("mm':'ss");
            timeText.text = timePlayingStr;

            yield return null;
        }
    }
}
