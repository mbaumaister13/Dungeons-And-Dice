using UnityEngine;
using Panda;
public class Ghoul : Enemy
{
    // Start is called before the first frame update
    Vector2 patrolStart;
    void Start()
    {
        hp = 20f;
        damage = 5;
        attackSpeed = 3f;
        patrolStart = transform.position;
    }


    [Task]
    public void Patrol() {
        if (Mathf.Abs(patrolStart.y - transform.position.y) > .2f) {
            rb.position = Vector2.MoveTowards(transform.position, patrolStart, Time.deltaTime * moveSpeed/2);
            attackTimer = Time.time;
            Task.current.Fail();
        }
        else {
            Task.current.Succeed();
        }
       
        rb.velocity = new Vector2(Mathf.Sin(Time.time), Mathf.Sin(Time.time * 6));
    }

    [Task]
    public void Swoop(){
        float target_height = player.transform.position.y;
        float current_height = transform.position.y;
        float smoothness = 0.95f;

        if (Time.time - attackTimer >= attackSpeed) {
            if (Mathf.Abs(target_height - current_height) > .1) {
                rb.position = new Vector2(smoothness * transform.position.x + (1.0f - smoothness) * player.transform.position.x, smoothness * current_height + (1.0f - smoothness) * target_height);
            }
            else {
                attackTimer = Time.time;
                Task.current.Succeed();
            }
        }
        else {
            Task.current.Fail();
        }
    }
    public override void attack(){
        player.takeDamage(damage);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            attack();
        }
    }
}
