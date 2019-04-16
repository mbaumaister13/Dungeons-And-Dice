using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy enemy;
    Animator animator;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            PlayerManager.instance.player.GetComponent<PlayerController>().takeDamage(enemy.damage);
        }
        animator.SetTrigger("destroyed");
        rb.velocity = Vector2.zero;
        Destroy(gameObject, 1f);
    }
}
