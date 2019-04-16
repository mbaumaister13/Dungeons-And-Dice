using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    FireGhoul enemy;
    Animator animator;
    Rigidbody2D rb;
    bool active = true;
    float lifespan = 3f, timer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemy = GameObject.Find("Fire Ghoul").GetComponent<FireGhoul>();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer >= lifespan) {
            destroy();
        }
    }
    void destroy() {
        active = false;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("explode");
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Untagged") {
            if (collision.tag == "Player"&&active) {
                PlayerManager.instance.player.GetComponent<PlayerController>().takeDamage(enemy.damage);
            }
            destroy();
        }
    }
}
