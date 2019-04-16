using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class FireGhoul : Enemy
{
    public GameObject projectile;
    private List<Object> fireballs = new List<Object>();
    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        damage = 5;
        attackSpeed = 2f;
    }
    public override void Update() {
        base.Update();
        animator.SetFloat("hp", hp);

    }

    [Task]
    public override void attack() {
        if(Time.time)
        GameObject fireball = Instantiate(projectile,transform);
        fireball.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position)*10);
        fireballs.Add(fireball);
    }


}
