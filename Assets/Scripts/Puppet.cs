using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet : MonoBehaviour
{
    private Rigidbody2D puppet;
    public int health = 100;
    public Animator animator;
    public Collider2D charcol;
    // Start is called before the first frame update
    void Start()
    {
        puppet = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage){
        animator.SetTrigger("damage");
        health -= damage;
    }


    public void StopDamage(){
        animator.SetTrigger("endDamage");
    }


    public void endFall(){
        animator.SetTrigger("end");
        Physics2D.IgnoreCollision(puppet.GetComponent<Collider2D>(), charcol);
    }
    // Update is called once per frame
    
    
    void Update()
    {
        if(health <= 0){
            animator.SetTrigger("fall");
        }
    }
}
