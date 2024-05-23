using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private ScoreManager _scoreManagerSCR;
    private TimerUI _timerUI_SCR;

    private Coroutine controlsUI_CR;

    [SerializeField] private GameObject controlsUI;
    [SerializeField] private GameObject crosshairUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject quotaCompleteUI;
    [SerializeField] private GameObject binUI;
    public GameObject wrongItemUI;

    [SerializeField] private TextMeshProUGUI winText;

    private void Awake()
    {
        _scoreManagerSCR = FindObjectOfType<ScoreManager>();
        _timerUI_SCR = GetComponent<TimerUI>();
    }

    void Start()
    {
        quotaCompleteUI.SetActive(false);
        wrongItemUI.SetActive(false);

        scoreUI.SetActive(true);
        timerUI.SetActive(true);
        crosshairUI.SetActive(true);
        controlsUI.SetActive(true);

        controlsUI_CR = StartCoroutine(CR_DisableControlsUI());
    }

    #region UI Button Interactions
    public void WinStatement()
    {
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        quotaCompleteUI.SetActive(true);

        float timePassed = _timerUI_SCR.timeElapsed;

        int minutes = Mathf.FloorToInt(timePassed / 60f);
        int seconds = Mathf.FloorToInt(timePassed % 60f);

        string timeFormatted = string.Format
            ("{0:0}" + " Minutes, and " + "{1:00}" + " Seconds!", minutes, seconds);

        winText.text = "You cleaned the park in " + timeFormatted + " Nice work!";

        binUI.SetActive(false);
        scoreUI.SetActive(false);
        timerUI.SetActive(false);
        crosshairUI.SetActive(false);
    }

    IEnumerator CR_DisableControlsUI()
    {
        yield return new WaitForSeconds(10);
        controlsUI.SetActive(false);
    }
    #endregion

    private void OnDestroy()
    {
        Time.timeScale -= Time.timeScale;

        StopAllCoroutines();
    }
}
