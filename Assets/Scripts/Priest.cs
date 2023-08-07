using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : MonoBehaviour
{
    private Rigidbody2D enemy;
    public LayerMask WhatIsBuffed;
    public float buffRange;
    public Transform BuffPosition;
    public float buffCooldown;
    private float tempBuffCooldown;
    public Animator animator;
    public int health;
    public Character plyr;
    public int value;
    private bool coinGiven = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        tempBuffCooldown = buffCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            if(!coinGiven){
                plyr.GiveCoin(value);
                coinGiven = true;
            }
            enemy.velocity = new Vector2 (0, 0);
            animator.SetTrigger("Die");
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), plyr.GetComponent<Collider2D>(), true);
        }
        if(tempBuffCooldown < -2){
            tempBuffCooldown = -1;
        }
        tempBuffCooldown -= Time.deltaTime;
        if(tempBuffCooldown <= 0){
        if(Mathf.Sqrt(
            ((plyr.transform.position.x - enemy.transform.position.x)*(plyr.transform.position.x - enemy.transform.position.x)) + 
            (((plyr.transform.position.y - enemy.transform.position.y)*(plyr.transform.position.y - enemy.transform.position.y))))
             <= buffRange){
            Buff();
            tempBuffCooldown = buffCooldown;
        }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(BuffPosition.position, buffRange);
    }
    void Buff(){
            animator.SetTrigger("Buff");
    }

    public void EndBuff(){
        Collider2D[] buffed = Physics2D.OverlapCircleAll(BuffPosition.position, buffRange, WhatIsBuffed);
            for(int i = 0; i < buffed.Length; i++){
                if(buffed[i].tag == "Enemy"){
                    buffed[i].GetComponent<Enemy>().health += 5;
                    buffed[i].GetComponent<Enemy>().damage += 5;
                }
                if(buffed[i].tag == "RangedEnemy"){
                    buffed[i].GetComponent<ProjectileEnemy>().health += 5;
                }
            }
        animator.SetTrigger("EndBuff");
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Damage");
    }
    public void EndDamage(){
        animator.SetTrigger("EndDamage");
    }
    public void Die(){
        Destroy(gameObject);
    }
}
