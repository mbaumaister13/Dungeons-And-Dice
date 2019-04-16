using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class FireGhoul : Enemy
{
    public GameObject projectile;
    bool enraged = false;
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
            enraged = true;
            attackSpeed = .5f;
        }
    }
    [Task]
    public void approachPlayer() {
        rb.position = Vector2.MoveTowards(transform.position,new Vector2(player.transform.position.x - transform.position.x, 0),Time.deltaTime*moveSpeed);
        Task.current.Succeed();
    }
    [Task]
    public override void attack() {
        if (Time.time - attackTimer >= attackSpeed && transform.childCount<5) {
            GameObject fireball = Instantiate(projectile, transform.position,transform.rotation);
            fireball.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position) * 30);
            attackTimer = Time.time;
            Task.current.Succeed();
        }
    }

    IEnumerator wait() {
        yield return new WaitForSecondsRealtime(3f);
    }

}
