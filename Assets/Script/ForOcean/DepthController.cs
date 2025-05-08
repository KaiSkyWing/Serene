using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int suitLev;
    private float depthStep = 30f;
    private float oxygenDepletionRateIncrement = 0.5f;
    private int previousDepthStep;
    private const int suitLevMultiplier = 5;
    [SerializeField] private OxygenController oxygenController;

    void Start()
    {
        suitLev = PlayerPrefs.GetInt("SuitLev");
        depthStep += suitLev * suitLevMultiplier;
    }

    void Update()
    {
        CalcDepth();
    }

    private void CalcDepth()
{
    float currentDepth = Mathf.Abs(player.transform.position.y);

    int currentDepthStep = Mathf.FloorToInt(currentDepth / depthStep);

    if (currentDepthStep != previousDepthStep)
    {
        int stepsChanged = currentDepthStep - previousDepthStep;

        oxygenController.oxygenDepletionRate += stepsChanged * oxygenDepletionRateIncrement;
        oxygenController.oxygenDepletionRate = Mathf.Max(0f, oxygenController.oxygenDepletionRate);
        previousDepthStep = currentDepthStep;

        Debug.Log($"Depth step: {currentDepthStep}, Oxygen depletion rate: {oxygenController.oxygenDepletionRate}");
    }
}

}
