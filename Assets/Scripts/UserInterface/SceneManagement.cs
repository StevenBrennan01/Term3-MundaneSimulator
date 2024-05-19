using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private UIManager _uiManagerSCR;

    private void Start()
    {
        _uiManagerSCR = FindObjectOfType<UIManager>();
    }

    public void StartGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void ControlsButton()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
