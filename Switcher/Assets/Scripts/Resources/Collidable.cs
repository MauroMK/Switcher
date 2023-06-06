using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    protected string playerTag = "Player";

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            // Show game over
        }    
    }
}
