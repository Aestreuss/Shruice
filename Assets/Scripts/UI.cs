using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public int coinAmount;

    public void UpdateCoins()
    {
        coinAmount += 10;
        coins.text = coinAmount.ToString();
    }
}
