using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Collidable
{
    private AudioSource audioSource;

    private BoxCollider2D boxColl;
    private SpriteRenderer spriteRenderer;

    private bool active = true;
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
        if (active)
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
        active = !active;

        // Verificar se o jogador está dentro do raio elétrico
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxColl.size, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag(playerTag))
            {
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag) && active)
        {
            GameManager.instance.RestartGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag) && active)
        {
            GameManager.instance.RestartGame();
        }
    }
}
