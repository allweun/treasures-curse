using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public ProjectileEnemy enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Character")
        {
            enemy.playerDetected = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "Character"){
            enemy.playerDetected = false;
        }

    }
}
