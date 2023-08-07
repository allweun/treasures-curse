using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    private Rigidbody2D enemyBody;
    public int health;
    private bool movingRight;
    public bool playerDetected = false;
    public GameObject bullet;
    public float cooldown;
    private float tempCooldown;
    public Character playerPosition;
    public Animator animator;
    private float timer = 1.0f;
    public int value;
    private bool coinGiven = false;
    // Start is called before the first frame update
    void Start()
    {
        bullet.gameObject.SetActive(false);
        enemyBody = GetComponent<Rigidbody2D>();
        tempCooldown = cooldown;
        Physics2D.IgnoreCollision(enemyBody.GetComponent<Collider2D>(), playerPosition.GetComponent<Collider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > -1){
            timer -= Time.deltaTime;
        }
        if(health <= 0){
            if(!coinGiven){
                playerPosition.GiveCoin(value);
                coinGiven = true;
            }
            Physics2D.IgnoreCollision(enemyBody.GetComponent<Collider2D>(), playerPosition.GetComponent<Collider2D>(), true);
            animator.SetTrigger("Die");
            bullet.SetActive(false);
        }

        if(playerDetected){
            if(tempCooldown <= 0){
                animator.SetTrigger("Attack");
                tempCooldown = cooldown;
            }
        }

        if(playerPosition.transform.position.x < transform.position.x && movingRight){
            Flip();
        }
        if(playerPosition.transform.position.x > transform.position.x && !movingRight){
            Flip();
        }
        if(tempCooldown < -2){
            tempCooldown = -1;
        }
        tempCooldown -= Time.deltaTime;
    }
    public void TakeDamage(int damage){
        health -= damage;
        animator.SetTrigger("Damage");
    }
    public void EndDamage(){
        animator.SetTrigger("EndDamage");
    }
    void Flip(){
        movingRight = !movingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void StopAttack(){
        animator.SetTrigger("StopAttack");
    }
    public void ThrowDart(){
        if(timer < 0){
            bullet.SetActive(true);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

    public void Dummy(){}
    public void GetBuff(){
        health += 5;
    }
}
