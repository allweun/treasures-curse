using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Character")
        {
            enemy.PlayerDetected = true;
        }
    }
}
