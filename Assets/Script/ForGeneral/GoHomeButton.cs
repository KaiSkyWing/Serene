using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomeButton : MonoBehaviour
{
    public void GoHomeClicked()
    {
        SceneManager.LoadScene("Town");
    }
}
