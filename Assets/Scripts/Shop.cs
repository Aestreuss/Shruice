using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button openShop;
    public Button closeShop;
    public GameObject openButton;
    public Button buyBlue;

    [Header ("Shrimp Types")]
    public GameObject blueberryShrimp;

    public int coinCheck;

    public GameObject shopInterface;

    public Transform spawnPoint1;

    public UI ui;

    private void Start()
    {
        openShop.onClick.AddListener(OpenShop);
        closeShop.onClick.AddListener(CloseShop);
        buyBlue.onClick.AddListener(BuyBlueShrimp);
    }

    public void UpdateFunds()
    {
        coinCheck += 10;
    }

    void DeductCoins()
    {
        coinCheck -= 20;
    }

    void OpenShop()
    {
        shopInterface.SetActive(true);
        openButton.SetActive(false);
    }

    void CloseShop()
    {
        shopInterface.SetActive(false);
        openButton.SetActive(true);
    }
    void BuyBlueShrimp()
    {
        if (coinCheck >= 20)
        {
            GameObject newObject = Instantiate(blueberryShrimp, spawnPoint1.transform.position, Quaternion.identity);
            ui.SpentCoins();
            DeductCoins();
        }
    }

}
