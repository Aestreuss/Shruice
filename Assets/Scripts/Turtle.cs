using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shrimp"))
        {
            anim.Play("turtle eat");
            Destroy(other.gameObject);
            
        }
    }

}
