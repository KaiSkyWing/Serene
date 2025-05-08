using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private Toggle dontShowAgainToggle;
    private const string TutorialKey = "HasSeenTutorial";

    void Start()
    {
        if (PlayerPrefs.GetInt(TutorialKey) == 0)
        {
            ShowTutorial();
        }
        else
        {
            HideTutorial();
        }
    }

    // Show the tutorial window
    void ShowTutorial()
    {
        tutorialWindow.SetActive(true);
        dontShowAgainToggle.isOn = false;
        PauseGame();
    }

    // Hide the tutorial window
    public void HideTutorial()
    {
        tutorialWindow.SetActive(false);
        ResumeGame();
    }

    public void OnCloseTutorial()
    {
        if (dontShowAgainToggle.isOn)
        {
            PlayerPrefs.SetInt(TutorialKey, 1);
        }

        HideTutorial();
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}

