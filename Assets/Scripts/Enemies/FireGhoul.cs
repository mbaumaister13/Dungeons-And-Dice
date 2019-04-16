using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class FireGhoul : Enemy
{
    public GameObject projectile;
    float duration = 0, cdDuration = 0f;
    int dir = 0;
    bool cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        damage = 5;
        attackSpeed = 2f;
        moveSpeed = 10f;
    }
    public override void Update() {
        base.Update();
        animator.SetFloat("hp", hp);
        if (hp <= 50f) {
            attackSpeed = .5f;
        }

    }
    [Task]
    public void wander() {
        if (Time.time - duration >= 3f) {
            Task.current.Succeed();
            dir = Random.Range(-1, 1);
            Debug.Log(dir);
            duration = Time.time;
        }
        rb.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - transform.position.x, 0)*dir, Time.deltaTime * moveSpeed);
    }
    [Task]
    public override void attack() {
        if (Time.time - attackTimer >= attackSpeed && transform.childCount<3&&!cooldown) {
            Vector3 dir = player.transform.position - transform.position;
            GameObject fireball = Instantiate(projectile, transform.position+dir.normalized*1.5f,transform.rotation);
            fireball.GetComponent<Rigidbody2D>().AddForce(dir * 30);
            fireball.transform.parent = transform;
            attackTimer = Time.time;
            Task.current.Succeed();
        }
        if(transform.childCount == 3) {
            cooldown = true;
        }
        if (cooldown && Time.time - cdDuration > 3f) {
            cooldown = false;
        }
        if (!cooldown) {
            cdDuration = Time.time;
        }
        duration = Time.time;
        if (damaged) {
            attackTimer = Time.time;
            Task.current.Fail();
        }
    }

    IEnumerator approach() {
        float timePassed = 0;
        while (timePassed < 3) {
            // Code to go left here
            timePassed += Time.deltaTime;
            yield return null;
        }
    }

}
