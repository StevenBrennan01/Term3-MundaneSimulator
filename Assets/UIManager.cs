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

    // Start is called before the first frame update
    void Start()
    {
        controlsUI_CR = StartCoroutine(CR_DisableControlsUI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CR_DisableControlsUI()
    {
        yield return new WaitForSeconds(10);
        controlsUI.SetActive(false);
    }


}
