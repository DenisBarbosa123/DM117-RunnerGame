using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;

    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void Show()
    {
        animator.Play("fadeout");

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        animator.Play("fadein");

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
