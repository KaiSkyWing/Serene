using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    private int coinnum;
    [SerializeField] private GameObject coinPanel;
    [SerializeField] private Sprite openChest;
    private bool isObtainable = true;
    private SpriteRenderer sp;
    private const float panelShowDuration = 3.0f;

    private void Start() 
    {
        coinnum = PlayerPrefs.GetInt("Coin");
        sp = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player" && isObtainable)
        {
            coinnum += 1000;
            PlayerPrefs.SetInt("Coin", coinnum);
            coinPanel.SetActive(true);
            isObtainable = false;
            sp.sprite = openChest;
            StartCoroutine(SetActiveFalse());
        }
    }

    IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(panelShowDuration);
        coinPanel.SetActive(false);
    }
}
