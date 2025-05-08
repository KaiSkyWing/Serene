using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class BagButton : MonoBehaviour
{
    [SerializeField] private GameObject bagPanel;
    [SerializeField] private GameObject bagButton;
    private bool isBagOn = false;
    private RectTransform rectTransform;
    private Vector3 originalScale;
    private bool isAnimating = false;

    private void Start() 
    {
        rectTransform = bagButton.GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnBagClick()
    {
        bagPanel.SetActive(true);
        isBagOn = true;
        PauseGame();
    }

    private void Update() 
    {
        if (isBagOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bagPanel.SetActive(false);
                isBagOn = false;
                ResumeGame();
            }
        }
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    public void OnGetFish()
    {
        if (isAnimating) return;

        isAnimating = true;
        rectTransform.localScale = originalScale;
        
        rectTransform.DOScale(1.2f, 0.5f)
            .SetEase(Ease.InOutQuart)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => isAnimating = false);
    }


    
}
