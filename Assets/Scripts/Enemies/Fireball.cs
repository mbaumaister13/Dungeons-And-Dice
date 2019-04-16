using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    FireGhoul enemy;
    Animator animator;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemy = GameObject.Find("Fire Ghoul").GetComponent<FireGhoul>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            PlayerManager.instance.player.GetComponent<PlayerController>().takeDamage(enemy.damage);
            rb.velocity = Vector2.zero;
            animator.SetTrigger("explode");
            Destroy(gameObject, 1f);
        }
    }
}
