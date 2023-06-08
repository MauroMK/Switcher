using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : Collidable
{
    private BoxCollider2D boxColl;

    private void Start() 
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        boxColl.enabled = false;
    }
}
