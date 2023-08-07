using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //public Sprite pointNotReached;
    //public Sprite pointReached;
    public Character player;
    public Animator animator;
    public float respawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Character>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Character")
        {
            animator.SetTrigger("Change");
        }
    }

    public void changeAnimation()
    {
        animator.SetTrigger("Change2");
    }
    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //player.transform.position = player.respawnPoint;
        player.transform.position = player.respawnPoint;
        player.alive = true;
        player.gameObject.SetActive(true);
    }

    public void Dummy()
    {

    }
}

