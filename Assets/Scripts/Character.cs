using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Character : MonoBehaviour
{
    public float speed;
    private Rigidbody2D player;
    public bool facingRight = false;
    private GameObject checkpointLocation;
    public GameObject spawnPoint;
    public SettingsMenu settingsMenu;

    public int levelCoins;
    public int dieCount;
    #region Jump
    [Header("Jump")]
    public Transform groundCheck;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumps;
    private int tempJumps;
    public float jumpForce;
    private bool isJumped = false;
    public float groundAudioCooldown;
    private float tempGroundAudioCooldown;
    public float landSpeed;
    public float doubleJumpForceAddSpeed;
    #endregion

    #region Attack
    [Header("Attack")]
    public float startCooldown;
    private float cooldown;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int characterDamage = 25;
    public float attackCooldown;
    private float tempAttackCooldown;
    private bool combo = false;
    public float comboCooldown;
    private float tempComboCooldown;
    public int comboDamage = 30;
    public Vector2 knockVector;
    private bool attackWalk = false;
    private bool comboWalk = false;
    #endregion

    #region Health
    [Header("Health Bar")]
    public float health;
    public Image healthbar;
    public Image armorbar;
    public int tempHealth;
    public bool alive = true;
    private float totalhealth;
    public float Armor;
    private float totalArmor;
    #endregion

    #region Movement
    [Header("Movement")]
    public bool moveright;
    public bool moveleft;
    public bool movestop;
    public bool startFlip=false;
    #endregion

    [Header("Animation")]
    public Animator animator;

    public int coinCounts=0;
    public Text counText;
    public bool moveSound;
    public AnimationClip attackClip;
    public AnimationClip comboClip;
    public int level = 1;

    private TimeManager timeManager;
    private bool levelEnded;
    private bool levelEnd;

    ArrayList alist = new ArrayList();
    // Start is called before the first frame update
    public Vector3 respawnPoint;
    public Vector3 lastChckPoint;
    public Checkpoint chckpntt;
    public GameObject respawnLocation;

    public int passedLevel;
    public levelEnder levelEnder;
    private int tempCoin;
    private Chest chest;

    void Start()
    {

        respawnPoint = respawnLocation.transform.position;
        tempJumps = extraJumps;
        tempAttackCooldown = attackCooldown;
        tempComboCooldown = comboCooldown;
        tempGroundAudioCooldown = groundAudioCooldown;
        player = GetComponent<Rigidbody2D>();

        chckpntt = FindObjectOfType<Checkpoint>();
        settingsMenu = FindObjectOfType<SettingsMenu>();
        timeManager = FindObjectOfType<TimeManager>();
        player.transform.position = respawnPoint;
        if(startFlip){
            Flip();
        }
        if(PlayerPrefs.HasKey("coins")==false){
            PlayerPrefs.SetInt("coins",0);
        }
        Armor = PlayerPrefs.GetInt("exShield");
        totalArmor = Armor;
        characterDamage += PlayerPrefs.GetInt("exDamage");
        comboDamage = characterDamage;
        health += PlayerPrefs.GetInt("exHealth");
        totalhealth = health;
        tempCoin=PlayerPrefs.GetInt("coins");
        coinCounts=0;
        SetCount();
    }

    void Update()
    {
        tempHealth = Convert.ToInt32(health);
        #region Movement
        if (!levelEnded)
        {
            if(isGrounded){
            if (moveSound)
            {
                FindObjectOfType<AudioManager>().Play("Walk");
            }
            else if (!moveSound)
            {
                FindObjectOfType<AudioManager>().Stop("Walk");
            }}
        }
        if(alive){
        if (moveright)
        {
            player.velocity = new Vector2(1 * speed, player.velocity.y);
            if (!facingRight)
            {
                //Flip();        
            }
            else
            {
                Flip();
            }

        }
        if (moveleft)
        {
            player.velocity = new Vector2(-1 * speed, player.velocity.y);
            if (facingRight)
            {
                //Flip();        
            }
            else
            {
                Flip();
            }
        }
        }

        /* 
        
        */
        if (!levelEnd)
        {
            if (movestop)
            {
                player.velocity = new Vector2(0.0f, player.velocity.y);
            }
        }
        #endregion


        #region Jump
        if (isGrounded && isJumped)
        {
            if (tempGroundAudioCooldown < 0)
            {
                FindObjectOfType<AudioManager>().Play2("Hground");
                isJumped = false;
            }
        }
        if (isGrounded)
        {
            tempJumps = extraJumps;
            animator.SetBool("Grounded", true);
        }
        if (!isGrounded)
        {
            isJumped = true;
            animator.SetBool("Grounded", false);
        }
        if (player.velocity.y < landSpeed)
        {
            player.velocity = new Vector2(player.velocity.x, landSpeed);
        }
        #endregion

        #region Delta time
        tempAttackCooldown -= Time.deltaTime;
        tempGroundAudioCooldown -= Time.deltaTime;
        if (combo == true)
        {
            tempComboCooldown -= Time.deltaTime;
        }
        if (tempComboCooldown < 0)
        {
            combo = false;
        }
        if (tempComboCooldown < -2)
        {
            tempComboCooldown = -1;
        }
        if (tempAttackCooldown < -2)
        {
            tempAttackCooldown = -1;
        }
        if (tempGroundAudioCooldown < -2)
        {
            tempGroundAudioCooldown = -1;
        }
        #endregion

        animator.SetFloat("Playerspeed", Mathf.Abs(player.velocity.x));
        animator.SetFloat("Jump", player.velocity.y);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        healthbar.fillAmount = health / totalhealth;
        armorbar.fillAmount = Armor / totalArmor;
        if (isGrounded)
        {
            //FindObjectOfType<AudioManager>().Play("Hground");
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    IEnumerator AttackWalk()
    {
        alive = false;
        if(attackWalk == true){   // Yürürken vurma zımbırtısı
            float waitTime = attackClip.length;
            yield return new WaitForSeconds(waitTime);
            attackWalk = false;
        }
        if(comboWalk == true){
            float waitTime = comboClip.length;
            yield return new WaitForSeconds(waitTime);
            comboWalk = false;
        }
    }

    public void Jump()
    {
        isJumped = true;
        animator.SetBool("Grounded", false);
        tempGroundAudioCooldown = groundAudioCooldown;
        if (tempJumps > 0)
        {
            player.velocity = new Vector2(player.velocity.x, 0);
            if (player.velocity.y < doubleJumpForceAddSpeed)
            {
                player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                tempJumps--;
                FindObjectOfType<AudioManager>().Play2("Jump");
                return;
            }
            player.AddForce(new Vector2(0, jumpForce * 1.2f), ForceMode2D.Impulse);
            tempJumps--;
            FindObjectOfType<AudioManager>().Play2("Jump");
        }
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
        if (combo == true)
        {
            animator.SetBool("Attack", false);
            FindObjectOfType<AudioManager>().Play2("AttackSword");
            animator.SetBool("Combo", true);
            alive = false;
            player.velocity = new Vector2(0,player.velocity.y);
            comboWalk = true;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].tag == "Enemy")
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(comboDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    tempAttackCooldown += 0.2f;
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                }
                if (enemies[i].tag == "RangedEnemy")
                {
                    enemies[i].GetComponent<ProjectileEnemy>().TakeDamage(comboDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    tempAttackCooldown += 0.2f;
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                }
                if (enemies[i].tag == "PassiveEnemy")
                {
                    enemies[i].GetComponent<PassiveEnemy>().TakeDamage(comboDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    tempAttackCooldown += 0.2f;
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                }
                if (enemies[i].tag == "Priest")
                {
                    enemies[i].GetComponent<Priest>().TakeDamage(comboDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    tempAttackCooldown += 0.2f;
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                }
                if (enemies[i].tag == "Puppet")
                {
                    enemies[i].GetComponent<Puppet>().TakeDamage(comboDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    tempAttackCooldown += 0.2f;
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                }
            }
            StartCoroutine(AttackWalk());
            combo = false;
            return;
        }
        if (tempAttackCooldown < 0)
        {
            animator.SetBool("Attack", true);
            FindObjectOfType<AudioManager>().Play2("AttackSword");
            alive = false;
            player.velocity = new Vector2(0,player.velocity.y);
            attackWalk = true;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].tag == "Enemy")
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(characterDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                    combo = true;
                }
                if (enemies[i].tag == "RangedEnemy")
                {
                    enemies[i].GetComponent<ProjectileEnemy>().TakeDamage(characterDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                    combo = true;
                }
                if (enemies[i].tag == "PassiveEnemy")
                {
                    enemies[i].GetComponent<PassiveEnemy>().TakeDamage(characterDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                    combo = true;
                }
                if (enemies[i].tag == "Priest")
                {
                    enemies[i].GetComponent<Priest>().TakeDamage(characterDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                    combo = true;
                }
                if (enemies[i].tag == "Puppet")
                {
                    enemies[i].GetComponent<Puppet>().TakeDamage(characterDamage);
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                    combo = true;
                }
                if (enemies[i].tag == "Chest")
                {
                    if(enemies[i].GetComponent<Chest>().chestOpened==1){
                        coinCounts += enemies[i].GetComponent<Chest>().value;
                        int tempcoinCounts = enemies[i].GetComponent<Chest>().value;
                        int tempprefcoins = PlayerPrefs.GetInt("coins");
                        tempprefcoins += tempcoinCounts;
                        PlayerPrefs.SetInt("coins",tempprefcoins);
                        FindObjectOfType<AudioManager>().Play2("coin");
                    }
                    enemies[i].GetComponent<Chest>().GetCoin();
                    SetCount();
                    FindObjectOfType<AudioManager>().Play2("Attack");
                    //enemies[i].GetComponent<Enemy>().Knockback(facingRight, knockVector);
                }
            }
            StartCoroutine(AttackWalk());
            tempComboCooldown = comboCooldown;
            tempAttackCooldown = attackCooldown;
        }
    }

    public void TakeDamage(int damage)
    {
        if(Armor > 0){
            if(damage < Armor){
                Armor -= damage;
            }else if(damage >= Armor){
                float tempDamage = damage - Armor;
                Armor = 0;
                health -= tempDamage;
            }
        }else if(Armor <= 0){
            health -= damage;
        }
        FindObjectOfType<AudioManager>().Play2("Dtaken");
        if (health <= 0)
        {
            alive = false; // karakterin hareketini kilitler
            animator.SetTrigger("Die");
            player.velocity = new Vector2 (0, 0);
            return;
            //if (lastChckPoint == null)
            //{
            //    Debug.Log(respawnLocation);
            //    player.transform.position = respawnPoint;
            //}
            //chckpntt.Respawn();
            //health = 100;
        }
        animator.SetTrigger("Damaged");
    }
    public void GiveCoin(int coin){
        coinCounts+=coin;
        SetCount();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCounts+=10;
            levelCoins+=10;
            FindObjectOfType<AudioManager>().Play2("coin");
            SetCount();
        }
        if (other.gameObject.CompareTag("Coin1"))
        {
            Destroy(other.gameObject);
            coinCounts++;
            levelCoins++;
            FindObjectOfType<AudioManager>().Play2("coin");
            SetCount();
            
        }
        if (other.gameObject.CompareTag("Coin5"))
        {
            Destroy(other.gameObject);
            coinCounts+=5;
            levelCoins+=5;
            FindObjectOfType<AudioManager>().Play2("coin");
            SetCount();
            
        }
        if (other.tag == "chck")
        {

            lastChckPoint = other.transform.position;
            respawnPoint = lastChckPoint;
        }

        if (other.tag == "LevelEnd")
        {
            settingsMenu.CloseUI();
            levelEnd = true;
            levelEnder.EndedLevel();
            PlayerPrefs.SetInt("coins",(tempCoin+coinCounts));
            EndMove();
        }
        if (other.tag == "levelEnderMove")
        {
            levelEnded = true;
            player.velocity = new Vector2(0 * speed, player.velocity.y);
            FindObjectOfType<AudioManager>().Stop("Walk");
            timeManager.Finished();
            settingsMenu.EndThisLevel();
        }
        if (other.tag == "RespawnPoint")
        {
            //Save Al
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = col.transform;
            FindObjectOfType<AudioManager>().Stop("Hground");
        }
        if(col.gameObject.tag == "Enemy"){
            
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }

    void SetCount()
    {
        counText.text = ":" + (tempCoin+coinCounts).ToString();
        
    }
    public void stopAttacking()
    {
        animator.SetBool("Attack", false);
        alive = true;
    }
    public void stopCombo()
    {
        animator.SetBool("Combo", false);
        alive = true;
        //animator.SetBool("Attack", false);
    }
    public void jumpPhase2()
    {
        animator.SetTrigger("Jump2");
    }

    public void landPhase2()
    {
        animator.SetTrigger("Land");
    }
    public void EndMove()
    {
        player.velocity = new Vector2(1 * speed, player.velocity.y);
        //Save Al
    }
    public void Die(){
        dieCount++;
        if (lastChckPoint == null)
            {
                player.transform.position = respawnPoint;
            }
            chckpntt.Respawn();
            health = 100;
            health += PlayerPrefs.GetInt("exHealth");
    }
    public void DamageEnd(){
        animator.SetTrigger("DamageEnd");
    }
}
