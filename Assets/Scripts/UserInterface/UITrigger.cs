using System.Collections;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    [SerializeField] private Animator setAnim;

    [SerializeField] private GameObject setUI;

    private void Awake()
    {
        setUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            setAnim.Play("BinOpen");
            setUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            setAnim.Play("BinClose");
            setUI.SetActive(false);
        }
    }
}
