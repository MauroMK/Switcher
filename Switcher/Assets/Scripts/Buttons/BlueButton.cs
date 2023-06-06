using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : Collidable
{
    [SerializeField] private InvisibleObjects[] objects;
    private BoxCollider2D boxColl;

    private void Start() 
    {
        boxColl = GetComponent<BoxCollider2D>();

        
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            AudioManager.instance.PlaySound("Button");
            ShowInvisibleObjects();
            boxColl.enabled = false;
        }
    }

    private void ShowInvisibleObjects()
    {
        foreach (InvisibleObjects objct in objects)
        {
            objct.boxCollider = objct.GetComponent<BoxCollider2D>();
            objct.spriteRenderer = objct.GetComponent<SpriteRenderer>();

            objct.boxCollider.isTrigger = false;
            objct.spriteRenderer.enabled = true;
        }
    }

}
