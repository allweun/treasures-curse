using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCol : MonoBehaviour
{
    public GameObject attackButton;
    public GameObject text;
    void OnTriggerEnter2D(Collider2D tag){
        if(tag.CompareTag("Character")){
            attackButton.SetActive(true);
            text.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Character")){
            text.SetActive(false);
        }
    }
}
