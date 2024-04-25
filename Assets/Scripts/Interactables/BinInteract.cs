using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BinInteract : MonoBehaviour
{
    [SerializeField]
    private Animator binAnim;

    [SerializeField]
    private GameObject binUI;

    private void Awake()
    {
        binUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            binAnim.Play("BinOpen");
            binUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            binAnim.Play("BinClose");
            binUI.SetActive(false);
        }
    }
}
