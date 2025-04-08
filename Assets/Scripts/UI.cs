using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public int coinAmount;
    public Button closeInfo;
    public GameObject infoBubble;
    public GameObject closeInfoButton;

    void Start()
    {
        closeInfo.onClick.AddListener(Info);
    }
    public void UpdateCoins()
    {
        coinAmount += 10;
        coins.text = coinAmount.ToString();
    }

    public void SpentCoins()
    {
        coinAmount -= 20;
        coins.text = coinAmount.ToString();
    }

    void Info()
    {
        Destroy(infoBubble);
        closeInfoButton.SetActive(false);
    }
}
