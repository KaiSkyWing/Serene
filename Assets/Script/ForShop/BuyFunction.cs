using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFunction : MonoBehaviour
{
    private int coinnum;
    private int oxyLev;
    private int suitLev;
    private int attackLev;

    [SerializeField] private GameObject buyWindow;
    
    private void Start() 
    {
        LoadNum();
    }

    public void BuyButton()
    {
        LoadNum();
        buyWindow.SetActive(true);
    }

    public void BuyOxy()
    {
        if(coinnum >= 100)
        {
            coinnum -= 100;
            oxyLev++;
            PlayerPrefs.SetInt("Coin", coinnum);
            PlayerPrefs.SetInt("OxyLev", oxyLev);
        }
        buyWindow.SetActive(false);
    }

    public void BuySuit()
    {
        if(coinnum >= 100)
        {
            coinnum -= 100;
            suitLev++;
            PlayerPrefs.SetInt("Coin", coinnum);
            PlayerPrefs.SetInt("SuitLev", suitLev);
        }
        buyWindow.SetActive(false);
    }

    public void BuyAttack()
    {
        if(coinnum >= 100)
        {
            coinnum -= 100;
            attackLev++;
            PlayerPrefs.SetInt("Coin", coinnum);
            PlayerPrefs.SetInt("SuitLev", attackLev);
        }
        buyWindow.SetActive(false);
    }

    public void Cancel()
    {
        buyWindow.SetActive(false);
    }

    private void LoadNum()
    {
        coinnum = PlayerPrefs.GetInt("Coin");
        oxyLev = PlayerPrefs.GetInt("OxyLev");
        suitLev = PlayerPrefs.GetInt("SuitLev");
        attackLev = PlayerPrefs.GetInt("AttackLev");
    }
}
