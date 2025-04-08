using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shrimp : MonoBehaviour
{
    [Header("shrimp movement")]
    public Vector2 targetPos;
    public bool isMoving = false;
    public float maxRange;
    public float waitTime;
    public float speed;
    public Vector2 originalPos;

    [Header("shrimp grow time")]
    public Shop shrimpSpawn;
    public float shrimpGrowTime;

    public bool shrimpCanFeed = false;

    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonReleased;



    void Start()
    {
        shrimpSpawn = transform.GetComponent<Shop>();
        originalPos = transform.position;
        Invoke("HasGrown", shrimpGrowTime);
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

    private void HasGrown()
    {
        StopAllCoroutines();
        shrimpCanFeed = true;
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


    private void OnMouseDown()
    {
        Debug.Log("clicking");
        mouseButtonReleased = false; //checks for mouse
        // calculates offset between mouse position and the center of the game object that will be dragged (without this it will jump directly to the mouse pointer)
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        if (shrimpCanFeed == true)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
        }


    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true; //checks for mouse 
    }
}
