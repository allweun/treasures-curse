using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    public Character player;
    public Vector2 knockVector;
    private float timer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > -1)
        {
            timer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (player.health > 0)
        {
            if (timer < 0)
            {
                if (col.tag == "Character")
                {
                    player.TakeDamage(System.Convert.ToInt32(damage));
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (player.health > 0)
        {
            if (timer < 0)
            {
                if (col.gameObject.tag == "Character")
                {
                    player.TakeDamage(System.Convert.ToInt32(damage));
                }
            }
        }
    }
}
