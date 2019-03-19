using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    //string name;
    protected Rigidbody2D rb;
    protected int dmg;
    public float hp;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_2D");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void attack(){

    }
    public virtual void Damage() {

    }
}
