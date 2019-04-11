using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
public class Ghoul : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 20f;
        damage = 5;
        attackSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,Mathf.Sin(Time.time*6));
    }


    
    [Task]
    public override void attack(){
        attackTimer = Time.time;
        Task.current.Succeed();
    }
}
