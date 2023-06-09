using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : Collidable
{
    private float fallingTime = 1f;
    private TargetJoint2D targetJ;
    private BoxCollider2D boxCollider;

    void Start()
    {
        targetJ = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Invoke("Fall", fallingTime);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }    
    }

    void Fall()
    {
        targetJ.enabled = false;
        boxCollider.isTrigger = true;
    }
}
