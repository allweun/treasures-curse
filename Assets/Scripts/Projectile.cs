using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    public Vector2 bulletDirection;
    public Character target;
    public int bulletDamage;
    public Vector2 knckvec;
    public float Angle;
    public float Angle2;
    public bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Character>();
        bulletDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(bulletDirection.x, 0);
        if(target.transform.position.x < transform.position.x && movingRight){
            Flip();
        }
        if(target.transform.position.x > transform.position.x && !movingRight){
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Character"){
            target.TakeDamage(bulletDamage);
            gameObject.SetActive(false);   
        }
        if(col.tag == "Tileset"){
            gameObject.SetActive(false); 
        }
    }
    void Flip(){
        movingRight = !movingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
