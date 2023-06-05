using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            // Show game over
        }    
    }
}
