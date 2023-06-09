using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Collidable
{
    private AudioSource audioSource;

    private BoxCollider2D boxColl;
    private SpriteRenderer spriteRenderer;

    private bool ativo = true;
    [SerializeField] private float coolDown;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxColl = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("AlternarAtivacao", coolDown, coolDown);
    }

    private void Update()
    {
        if (ativo)
        {
            boxColl.isTrigger = false;
            spriteRenderer.enabled = true;
            
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            boxColl.isTrigger = true;
            spriteRenderer.enabled = false;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void AlternarAtivacao()
    {
        ativo = !ativo;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GameManager.instance.RestartGame();
        }
    }
}
