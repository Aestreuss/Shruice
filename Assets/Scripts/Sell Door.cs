using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellDoor : MonoBehaviour
{
    public UI ui;
    public GameObject blueberry;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Juice"))
        {
            Debug.Log("destroy");
            Destroy(other.gameObject);
            ui.UpdateCoins();
        }
    }
}
