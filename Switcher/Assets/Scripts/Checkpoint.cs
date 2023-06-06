using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Collidable
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GameManager.instance.LoadNextScene();
        }
    }
}
