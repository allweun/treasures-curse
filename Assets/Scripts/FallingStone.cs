using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    public float fallspeed;
    private Rigidbody2D stone;
    // Start is called before the first frame update
    void Start()
    {
        stone = GetComponent<Rigidbody2D>();
        stone.velocity=new Vector2(0,fallspeed);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(transform.position.x, fallspeed, transform.position.z);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("DestroyRock")){
            Destroy(gameObject);
        }
    }
}
