using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RedButton : Collidable
{
    private BoxCollider2D boxColl;
    private Saw sawScript;

    [SerializeField] private float newSawSpeed;

    [SerializeField] private Light2D lightToModify;
    [SerializeField] private float newIntensity;

    private void Start() 
    {
        sawScript = FindObjectOfType<Saw>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            AudioManager.instance.PlaySound("Button");
            SwitchLightIntensity();
            sawScript.speed = newSawSpeed;
            boxColl.enabled = false;
        }
    }

    private void SwitchLightIntensity()
    {
        lightToModify.intensity = newIntensity;
    }
}
