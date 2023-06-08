using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GreenButton : Collidable
{
    [SerializeField] private InvisibleObjects[] objects;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private float newIntensity;
    private BoxCollider2D boxColl;

    private void Start() 
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.instance.PlaySound("Button");
        ShowInvisibleObjects();
        TurnOffLights();
        boxColl.enabled = false;
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

    private void TurnOffLights()
    {
        globalLight.intensity = newIntensity;
    }
}
