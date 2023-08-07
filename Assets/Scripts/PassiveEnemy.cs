using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemy : MonoBehaviour
{
    private Rigidbody2D enemy;
    public int health;
    public float speed;
    public Transform damageGivePosition;
    public LayerMask whatIsPlayer;
    public float damageGiveRange;
    public int damage;
    public float attackSpeed;
    public float tempAttackSpeed;
    private bool movingRight = false;
    public Transform patrolDirection1;
    public Transform patrolDirection2;
    public Animator animator;
    private float tempFlipDelay;
    private float delayTime = 0.7f;
    public Character plyr;
    private bool alive = true;
    public int value;
    private bool coinGiven = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        tempAttackSpeed = attackSpeed;
        tempFlipDelay = delayTime;
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), plyr.GetComponent<Collider2D>(), true);
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
            alive = false;
        }
        Collider2D player = Physics2D.OverlapCircle(damageGivePosition.position, damageGiveRange, whatIsPlayer);
        if(player){
            if(player.tag == "Character"){
                if(alive){
                        if(tempAttackSpeed < 0){
                        player.GetComponent<Character>().TakeDamage(damage);
                        tempAttackSpeed = attackSpeed;
                    }
                }
            }
        }
        if(alive){
        if (movingRight){
            enemy.velocity = new Vector2(1 * speed, enemy.velocity.y);
        }
        if (!movingRight){
            enemy.velocity = new Vector2(-1 * speed, enemy.velocity.y);
        }
        if (Mathf.Abs(enemy.transform.position.x - patrolDirection1.position.x) < 0.5 || Mathf.Abs(enemy.transform.position.x - patrolDirection2.position.x) < 0.5){
            if (tempFlipDelay < 0)
            {
                Flip();
                tempFlipDelay = delayTime;
            }
        }
        }
        tempAttackSpeed -= Time.deltaTime;
        tempFlipDelay -= Time.deltaTime;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Scare");
    }
    public void Endscare(){
        animator.SetTrigger("Endscare");
    }
    public void Dummy(){}
    void Flip()
    {
        movingRight = !movingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(damageGivePosition.position, damageGiveRange);
    }

    public void Die(){
        Destroy(gameObject);
    }
}
