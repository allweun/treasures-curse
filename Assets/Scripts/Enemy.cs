using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyBody;
    public int health;
    public float speed;
    public Transform damageGivePosition;
    public float damageGiveRange;
    public LayerMask whatIsPlayer;
    public int damage;
    public int kickBackForce;
    public float attackSpeed;
    private float tempSpeed;
    private bool movingRight = true;
    public bool PlayerDetected = false;
    private float tempFlipDelay;
    private float delayTime = 1;
    public Character playerposition;
    public float distanceBetweenplayer;
    private bool detectAttack = false;
    private bool alive = true;
    private bool canmove = true;

    // public Transform groundDetection;
    public float attackDelay;
    // public LayerMask whatIsGround;
    // public float groundDetectionDistance;
    //public GameObject deathParticle;
    //public int detectionMode = 1;
    public Transform patrolDirection1;
    public Transform patrolDirection2;
    public int value;
    private bool coinGiven=false;

    public Animator enemyanimator;
    private bool attacking;
    public GameObject EnemyScale;
    public Vector2 knockVector;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        tempSpeed = attackSpeed;
        enemyanimator = GetComponent<Animator>();
        tempFlipDelay = delayTime;
        //Physics2D.IgnoreCollision(enemyBody.GetComponent<Collider2D>(), playerposition.GetComponent<Collider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            if(!coinGiven){
                playerposition.GiveCoin(value);
                coinGiven = true;
            }
            Physics2D.IgnoreCollision(enemyBody.GetComponent<Collider2D>(), playerposition.GetComponent<Collider2D>(), true);
            enemyanimator.SetTrigger("Die");
            alive = false;
            Physics2D.IgnoreCollision(enemyBody.GetComponent<Collider2D>(), playerposition.GetComponent<Collider2D>(), true);
            //Destroy(gameObject);
            //Instantiate(deathParticle, enemyBody.transform.position, enemyBody.transform.rotation);
        }
        Collider2D player = Physics2D.OverlapCircle(damageGivePosition.position, damageGiveRange, whatIsPlayer);
        if (tempSpeed < 0)
        {
            if (player)
            {
                if (PlayerDetected)
                {
                    enemyanimator.SetBool("Attack", true);
                    //player.GetComponent<Character>().TakeDamage(damage);
                    detectAttack = true;
                    tempSpeed = attackSpeed;
                    canmove = false;
                }
            }
        }
        if (tempSpeed < -10)
        {
            tempSpeed = -1;
        }
        tempSpeed -= Time.deltaTime;
        tempFlipDelay -= Time.deltaTime;


        if (!PlayerDetected)
        {
            if (Mathf.Abs(enemyBody.transform.position.x - patrolDirection1.position.x) < 0.5 || Mathf.Abs(enemyBody.transform.position.x - patrolDirection2.position.x) < 0.5)
            {
                if (tempFlipDelay < 0)
                {
                    Flip();
                    tempFlipDelay = delayTime;
                }
            }
        }
        if(alive){
        if (PlayerDetected)
        {
            if (detectAttack)
                DelayAttack();
            if(canmove){
            if (enemyBody.transform.position.x < playerposition.transform.position.x)
            {
                if (movingRight)
                {
                    if (Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) > distanceBetweenplayer)
                    {
                        enemyBody.velocity = new Vector2(1 * speed, enemyBody.velocity.y);
                    }
                    if (Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) < distanceBetweenplayer)
                    {
                        enemyBody.velocity = new Vector2((1 * speed) / 2, enemyBody.velocity.y);
                    }
                    if(Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) < (distanceBetweenplayer / 2)){
                        enemyBody.velocity = new Vector2 (0 , enemyBody.velocity.y);
                    }
                }
                else
                {
                    Flip();
                }
            }
            if (enemyBody.transform.position.x > playerposition.transform.position.x)
            {
                if (!movingRight)
                {
                    if (Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) > distanceBetweenplayer)
                    {
                        enemyBody.velocity = new Vector2(-1 * speed, enemyBody.velocity.y);
                    }
                    if (Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) < distanceBetweenplayer)
                    {
                        enemyBody.velocity = new Vector2((-1 * speed) / 2, enemyBody.velocity.y);
                    }
                    if(Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) < (distanceBetweenplayer / 2)){
                        enemyBody.velocity = new Vector2 (0 , enemyBody.velocity.y);
                    }
                }
                else
                {
                    Flip();
                }
            }
            }
            if ((Mathf.Abs(enemyBody.transform.position.x - playerposition.transform.position.x) > 15))
            {
                PlayerDetected = false;
                enemyBody.velocity = new Vector2(0, enemyBody.velocity.y);
            }
        }
        }


        if (tempFlipDelay < -2)
        {
            tempFlipDelay = -1;
        }

        if (!PlayerDetected)
        {
            if (movingRight)
            {
                enemyBody.velocity = new Vector2(1 * speed, enemyBody.velocity.y);
            }
            if (!movingRight)
            {
                enemyBody.velocity = new Vector2(-1 * speed, enemyBody.velocity.y);
            }
        }

        enemyanimator.SetFloat("MoveSpeed", Mathf.Abs(enemyBody.velocity.x));

    }

    public void DelayAttack()
    {
        StartCoroutine("DelayCoroutine");
    }
    public int GiveCoin(){
        return value;
    }

    public IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(attackDelay);
        detectAttack = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        enemyanimator.SetTrigger("Damage");
    }
    public void EndDamage(){
        enemyanimator.SetTrigger("EndDamage");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(damageGivePosition.position, damageGiveRange);
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void stopAttack()
    {
        enemyanimator.SetBool("Attack", false);
        canmove = true;
    }

    public void DamageGiveEvent(){
        Collider2D player = Physics2D.OverlapCircle(damageGivePosition.position, damageGiveRange, whatIsPlayer);
        if(player){
            player.GetComponent<Character>().TakeDamage(damage);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Character"){
            enemyBody.velocity = new Vector2 (0, enemyBody.velocity.y);
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

    public void Dummy(){}

    public void GetBuff(){
        health += 5;
        damage += 5;
    }
    
    }


