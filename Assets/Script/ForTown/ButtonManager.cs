using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnShopClick()
    {
        SceneManager.LoadScene("Shop");
    }

    public void OnPortClick()
    {
        SceneManager.LoadScene("Ocean");
    }

    public void OnResetClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
