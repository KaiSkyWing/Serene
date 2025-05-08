using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellFunction : MonoBehaviour
{
    private int clownnum;
    private int jellynum;
    private int sharknum;
    private int coinnum;
    private int crabnum;
    private int squidnum;
    [SerializeField] private ShowUI showUI;
    [SerializeField] private GameObject sellWindow;

    [SerializeField] private GameObject coinText;

    private RectTransform rectTransform;
    private Vector3 originalScale;

    private void Start() 
    {
        LoadNum();

        rectTransform = coinText.GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void SellButton()
    {
        LoadNum();
        sellWindow.SetActive(true);
    }

    private void AfterSellFish(int coinPlus)
    {
        rectTransform.localScale = originalScale;
        rectTransform.DOScale(1.2f, 0.5f).SetEase(Ease.InOutQuart).SetLoops(2, LoopType.Yoyo);
        coinnum += coinPlus;
        PlayerPrefs.SetInt("Coin", coinnum);
        showUI.ShowNum();
    }
    
    public void SellClown()
    {
        for (;clownnum >= 1;)
        {
            clownnum--;
            PlayerPrefs.SetInt("Clown", clownnum);
            AfterSellFish(100);
        }
        sellWindow.SetActive(false);
    }

    public void SellJelly()
    {
        for (;jellynum >= 1;)
        {
            jellynum--;
            PlayerPrefs.SetInt("Jelly", jellynum);
            AfterSellFish(200);
        }
        sellWindow.SetActive(false);
    }

    public void SellShark()
    {
        for (;sharknum >= 1;)
        {
            sharknum--;
            PlayerPrefs.SetInt("Shark", sharknum);
            AfterSellFish(400);
        }
        sellWindow.SetActive(false);
    }

    public void SellCrab()
    {
        for (;crabnum >= 1;)
        {
            crabnum--;
            PlayerPrefs.SetInt("Crab", crabnum);
            AfterSellFish(100);
        }
        sellWindow.SetActive(false);
    }

    public void SellSquid()
    {
        for (;squidnum >= 1;)
        {
            squidnum--;
            PlayerPrefs.SetInt("Squid", squidnum);
            AfterSellFish(200);
        }
        sellWindow.SetActive(false);
    }

    public void Cancel()
    {
        sellWindow.SetActive(false);
    }

    private void LoadNum()
    {
        coinnum = PlayerPrefs.GetInt("Coin");
        clownnum = PlayerPrefs.GetInt("Clown");
        jellynum = PlayerPrefs.GetInt("Jelly");
        sharknum = PlayerPrefs.GetInt("Shark");
        crabnum = PlayerPrefs.GetInt("Crab");
        squidnum = PlayerPrefs.GetInt("Squid");
    }

}
