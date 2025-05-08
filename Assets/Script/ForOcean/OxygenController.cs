using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour
{
    public Slider oxygenSlider;
    public Text oxygenLevelText;
    private float maxOxygen = 100f;
    private int oxyLev;
    public float currentOxygen;
    public float oxygenDepletionRate = 0.5f;
    private GameObject playerGameObject;
    private PlayerController playerController;
    private const float dashMultiplier = 2;
    private Image oxygenFillImage;

    void Start()
    {
        SetMaxOxy();
        currentOxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = currentOxygen;

        oxygenFillImage = oxygenSlider.fillRect.GetComponent<Image>();

        playerGameObject = GameObject.Find("Player");
        playerController = playerGameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isAlive)
        {
            DecreaseOxygen();
        }

        UpdateOxygenColor();
    }

    private void SetMaxOxy()
    {
        oxyLev = PlayerPrefs.GetInt("OxyLev");
        for (; oxyLev < 0; oxyLev--)
        {
            maxOxygen += 5;
        }
    }

    void DecreaseOxygen()
    {
        if (currentOxygen > 0)
        {
            if (playerController.isDash)
            {
                currentOxygen -= oxygenDepletionRate * dashMultiplier * Time.deltaTime;
            }
            else
            {
                currentOxygen -= oxygenDepletionRate * Time.deltaTime;
            }
            oxygenSlider.value = currentOxygen;
            oxygenLevelText.text = currentOxygen.ToString("f0");
        }
        else
        {
            currentOxygen = 0;
            playerController.isAlive = false;
            playerController.isDead = true;
        }
    }

    void UpdateOxygenColor()
    {
        float percentage = currentOxygen / maxOxygen;
        if (percentage > 0.5f)
        {
            oxygenFillImage.color = Color.Lerp(Color.yellow, Color.green, (percentage - 0.5f) * 2);
        }
        else
        {
            oxygenFillImage.color = Color.Lerp(Color.red, Color.yellow, percentage * 2);
        }
    }
}
