using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    private int coinnum;
    private int clownnum;
    private int jellynum;
    private int sharknum;
    private int crabnum;
    private int squidnum;
    [SerializeField] private Text coinNumText;
    [SerializeField] private Text clownNumText;
    [SerializeField] private Text jellyNumText;
    [SerializeField] private Text sharkNumText;
    [SerializeField] private Text crabNumText;
    [SerializeField] private Text squidNumText;

    private void Start() 
    {
        
    }

    private void Update() 
    {
        ShowNum();
    }

    public void ShowNum()
    {
        LoadNum();
        coinNumText.text = $"{coinnum}";
        clownNumText.text = $"{clownnum}";
        jellyNumText.text = $"{jellynum}";
        sharkNumText.text = $"{sharknum}";
        crabNumText.text = $"{crabnum}";
        squidNumText.text = $"{squidnum}";
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
