using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour
{
    public Character player;
    public Vector2 knockVector;
    public int damage;
    public float attackSpeed;
    private float tempSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
        tempSpeed = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(tempSpeed < -5){
            tempSpeed = -1;
        }
        tempSpeed -= Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D col){
        if(player.health > 0){
            if(tempSpeed < 0){
                player.TakeDamage(damage);
                tempSpeed = attackSpeed;
            }
        }
    }
}
