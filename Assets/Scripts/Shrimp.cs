using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shrimp : MonoBehaviour
{
    public Vector2 targetPos;
    public bool isMoving = false;
    public float maxRange;
    public float waitTime;
    public float speed;

    public Vector2 originalPos;

    public Shop shrimpSpawn;

    void Start()
    {
        shrimpSpawn = transform.GetComponent<Shop>();
        originalPos = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            FindNewPos();
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        }
    }

    private void FindNewPos()
    {
        targetPos = new Vector2();
        targetPos.x = Random.Range(originalPos.x - maxRange, originalPos.x + maxRange);
        targetPos.y = Random.Range(originalPos.y - maxRange, originalPos.y + maxRange);

        //transform.LookAt(targetPos);
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {
        isMoving = true;
        

        yield return new WaitForSeconds(waitTime);
        isMoving = false;
        yield return null;
    }



}
