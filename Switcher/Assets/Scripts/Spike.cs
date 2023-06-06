using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Collidable
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GameManager.instance.RestartGame();
        }
    }
}
