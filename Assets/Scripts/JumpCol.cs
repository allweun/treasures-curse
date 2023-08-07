using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCol : MonoBehaviour
{
    public GameObject JumpButton;
    public GameObject text;
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Character")){
            JumpButton.SetActive(true);
            text.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Character")){
            text.SetActive(false);
        }
    }
}
