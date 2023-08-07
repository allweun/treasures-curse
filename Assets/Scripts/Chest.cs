using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    private int deger;
    public int value;
    private bool CanGiveCoin = true;
    public string chestNum;
    public int chestOpened;
    public int a;
    void Awake()
    {
        if(!PlayerPrefs.HasKey(chestNum)){
            chestOpened = 1;
            CanGiveCoin = true;
            PlayerPrefs.SetInt(chestNum,chestOpened);
        }
        if(PlayerPrefs.HasKey(chestNum)){
            if(PlayerPrefs.GetInt(chestNum) == 0){
                CanGiveCoin = false;
                chestOpened = 0;
                FinishOpening();
            }
        }
        if(PlayerPrefs.HasKey(chestNum)){
            if(PlayerPrefs.GetInt(chestNum) == 1){
                CanGiveCoin = true;
                chestOpened = 1;
            }
        }
    }
    void Update(){
        
    }

    public void FinishOpening(){
        animator.SetTrigger("finish");
        a++;
    }

    public void GetCoin(){
        if(PlayerPrefs.GetInt(chestNum)==1){
        if(CanGiveCoin){
            animator.SetTrigger("openchest");
            chestOpened = 0;
            PlayerPrefs.SetInt(chestNum, chestOpened);
            value=0;
            CanGiveCoin = false;
        }
        }
    }


}
