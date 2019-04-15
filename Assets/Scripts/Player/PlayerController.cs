﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : Player
{
    SpriteRenderer sr;
    public Transform groundCheck;
    public BoxCollider2D wep;
    public float moveSpeed, jumpForce;
    bool movingRight = false, grounded = false;
    public LayerMask WhatIsGround;
    Rigidbody2D rb;
    Animator animator;
    float horizontalMove = 0f, groundRadius = .2f, wepOffset;
    //public MeterManager meterManager;
    TextMeshProUGUI HealthText, StrengthText, GoldText;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        wepOffset = wep.offset.x;
        HealthText = meterManager.transform.Find("PlayerMeters").transform.Find("Health").gameObject.GetComponent<TextMeshProUGUI>(); 
        StrengthText = meterManager.transform.Find("PlayerMeters").transform.Find("Strength").gameObject.GetComponent<TextMeshProUGUI>(); 
        GoldText = meterManager.transform.Find("PlayerMeters").transform.Find("Gold").gameObject.GetComponent<TextMeshProUGUI>(); 
    }

    void Update(){
        HealthText.SetText("Health: " + hp + " hp");
        StrengthText.SetText("Strength: x" + strength);
        GoldText.SetText("Gold: " + gold);
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if(!isInvincible){
            if (Input.GetKeyDown("space")&&grounded){
                rb.AddForce(new Vector2(0,jumpForce));
            }
            animator.SetFloat("vSpeed",rb.velocity.y);
            if(Input.GetMouseButtonDown(0)&&Time.time-attackTimer>=attackSpeed){
                if(horizontalMove!=0){
                    wep.offset = new Vector2(wepOffset*horizontalMove,wep.offset.y);
                }
                animator.SetTrigger("isAttacking");
                attackTimer = Time.time;
            }
        }
        if(Time.time - invincibilityTimer >= invincibilityTime){
            isInvincible = false;
        }
        if(hp<=0){
            Respawn();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isInvincible){
            grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,WhatIsGround);

            if (horizontalMove==1){
                if(!movingRight){
                    sr.flipX = false;
                    movingRight = true;
                    animator.SetBool("isFacingRight",true);
                }
            }
            if (horizontalMove==-1){
                if(movingRight){
                    sr.flipX = true;
                    movingRight = false;
                    animator.SetBool("isFacingRight",false);
                }
            }
            animator.SetBool("onGround",grounded);
            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
            rb.velocity = new Vector2 (horizontalMove* moveSpeed, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            Debug.Log("Enemy HIT");
            //Enemy.Damage();
        }
    }
    public void takeDamage(int damage){
        if(!isInvincible){
            hp-=damage;
            animator.SetTrigger("Damaged");
            invincibilityTimer = Time.time;
            isInvincible = true;
            Debug.Log(rb.velocity);
            Vector2 knockback = new Vector2(-rb.velocity.x,jumpForce/2);
            rb.AddForce(knockback);
            Debug.Log(rb.velocity);            
            Debug.Log("Player took "+damage+" damage!");
        }
    }
    void Respawn(){
        GameManager.unloadScene();
        PlayerManager.instance.respawnPlayer();
    }
}
