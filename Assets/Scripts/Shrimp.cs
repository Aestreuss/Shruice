using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public float shrimpGrowTime = 20f;
    public float growspeed;
    public float timer = 0f;
    public float maxSize = 0.4f;

    public bool isMaxSize = false;


    public bool shrimpCanFeed = false;

    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonReleased;



    void Start()
    {
        shrimpSpawn = transform.GetComponent<Shop>();
        originalPos = transform.position;

        if (!isMaxSize)
        {
            StartCoroutine(Grow());
        }

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

    private IEnumerator Grow()
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            transform.localScale = Vector2.Lerp(startScale, maxScale, timer / shrimpGrowTime);
            timer += Time.deltaTime * growspeed;
            yield return null;
        }
        while (timer < shrimpGrowTime);

        isMaxSize = true;
    }


    private void HasGrown()
    {
        shrimpCanFeed = true;
        StopAllCoroutines();
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

     void OnMouseDrag()
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
