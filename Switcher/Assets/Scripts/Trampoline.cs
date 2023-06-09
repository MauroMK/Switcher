using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : Collidable
{
    [SerializeField] private float jumpForce;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            anim.SetTrigger("jump");
            AudioManager.instance.PlaySound("Trampoline");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
