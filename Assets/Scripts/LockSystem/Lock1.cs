using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock1 : MonoBehaviour
{
    public Button button;
    public GameObject chain;
    void Update(){
        if(button.interactable){
            chain.SetActive(false);
        }else{
            chain.SetActive(true);
        }
    }    
}
