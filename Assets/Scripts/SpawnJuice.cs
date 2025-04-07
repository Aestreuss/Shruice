using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJuice : MonoBehaviour
{
    public GameObject juiceFlavour;

    private bool cooldown = false;
    public float cooldownTime;

    public Transform spawnPoint;



    void Update()
    {
        SpawnOneJuice();
    }

    void SpawnOneJuice()
    {
        if (cooldown == false)
        {
            GameObject newObject = Instantiate(juiceFlavour, spawnPoint.transform.position, Quaternion.identity);
            Invoke("ResetCooldown", cooldownTime);
            cooldown = true;
        }

    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
