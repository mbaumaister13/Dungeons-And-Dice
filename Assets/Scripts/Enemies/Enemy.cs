using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    protected PlayerController player;
    //string name;
    protected Rigidbody2D rb;
    protected int damage;
    public float hp;
    public float moveSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void attack(){    }
    public virtual void canSeePlayer(){
    }
}
