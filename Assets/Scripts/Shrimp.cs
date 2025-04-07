using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shrimp : MonoBehaviour
{

    public GameObject blueShrimp;
    public float Radius;

    public Button buyBBShrimp;
    public Button buyAShrimpp;

    public Vector2 blueberry;
    void Start()
    {
        buyBBShrimp.onClick.AddListener(SpawnBlueberry);
    }

    void SpawnBlueberry()
    {
        Vector2 randomPos = Random.insideUnitSphere * Radius;
        Instantiate(blueShrimp, randomPos, Quaternion.identity);

        
    }
    
}
