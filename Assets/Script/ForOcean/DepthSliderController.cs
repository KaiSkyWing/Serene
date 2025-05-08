using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthSliderController : MonoBehaviour
{
    [SerializeField] private Slider depthSlider;
    [SerializeField] private Transform player;

    private float maxDepth = 0f; 
    private float minDepth = -300f;

    void Update()
    {
        UpdateSliderValue();
    }

    void UpdateSliderValue()
    {
        float playerY = player.position.y;

        float normalizedDepth = Mathf.InverseLerp(minDepth, maxDepth, playerY);

        depthSlider.value = normalizedDepth;
    }
}

