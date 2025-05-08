using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Possesion : MonoBehaviour
{    private int clownnum;
    private int jellynum;
    private int sharknum;
    private int crabnum;
    private int squidnum;

    public Text fishNumText;
    public Text jellyNumText;
    public Text sharkNumText;
    public Text crabNumText;
    public Text squidNumText;
    

    private void Start() 
    {
        clownnum = PlayerPrefs.GetInt("Clown");
        jellynum = PlayerPrefs.GetInt("Jelly");
        sharknum = PlayerPrefs.GetInt("Shark");
        crabnum = PlayerPrefs.GetInt("Crab");
        squidnum = PlayerPrefs.GetInt("Squid");
        ShowFishUI(clownnum, FishClass.FishType.ClownFish);
        ShowFishUI(jellynum, FishClass.FishType.JerryFish);
        ShowFishUI(sharknum, FishClass.FishType.Shark);
        ShowFishUI(crabnum, FishClass.FishType.Crab);
        ShowFishUI(squidnum, FishClass.FishType.Squid);
    }

    public void CaptureFish(FishClass.FishType fishType)
    {
        //switch fishtype
        switch (fishType)
        {
            case FishClass.FishType.ClownFish:
            clownnum += 1;
            PlayerPrefs.SetInt("Clown", clownnum);
            ShowFishUI(clownnum, fishType);
            break;

            case FishClass.FishType.JerryFish:
            jellynum += 1;
            PlayerPrefs.SetInt("Jelly", jellynum);
            ShowFishUI(jellynum, fishType);
            break;

            case FishClass.FishType.Shark:
            sharknum += 1;
            PlayerPrefs.SetInt("Shark", sharknum);
            ShowFishUI(sharknum, fishType);
            break;

            case FishClass.FishType.Crab:
            crabnum += 1;
            PlayerPrefs.SetInt("Crab", crabnum);
            ShowFishUI(crabnum, fishType);
            break;

            case FishClass.FishType.Squid:
            squidnum += 1;
            PlayerPrefs.SetInt("Squid", squidnum);
            ShowFishUI(squidnum, fishType);
            break;
        }
        
    }

    public void ShowFishUI(int num, FishClass.FishType fishType)
    {
        switch (fishType)
        {
            case FishClass.FishType.ClownFish:
            fishNumText.text = $"{num}";
            break;

            case FishClass.FishType.JerryFish:
            jellyNumText.text = $"{num}";
            break;

            case FishClass.FishType.Shark:
            sharkNumText.text = $"{num}";
            break;

            case FishClass.FishType.Crab:
            crabNumText.text = $"{num}";
            break;

            case FishClass.FishType.Squid:
            squidNumText.text = $"{num}";
            break;
        }
    }
}
