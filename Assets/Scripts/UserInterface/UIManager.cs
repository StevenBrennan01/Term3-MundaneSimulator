using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject crosshairUI;

    private Coroutine controlsUI_CR;

    void Start()
    {
        controlsUI_CR = StartCoroutine(CR_DisableControlsUI());
    }

    IEnumerator CR_DisableControlsUI()
    {
        yield return new WaitForSeconds(10);
        controlsUI.SetActive(false);
    }


}
