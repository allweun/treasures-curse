using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Store : MonoBehaviour
{
    public GameObject storePanel1;
    public GameObject storePanel2;
    public GameObject storePanelAttack;
    public GameObject storePanelHealth;
    public GameObject storePanelShield;

    public Button Upgrade;
    
    public int moneyAmount;
    public void Start(){
        moneyAmount=PlayerPrefs.GetInt("coins");
        if(!PlayerPrefs.HasKey("exDamage"))
            PlayerPrefs.SetInt("exDamage",0);
        if(!PlayerPrefs.HasKey("exHealth"))
            PlayerPrefs.SetInt("exHealth",0);
        if(!PlayerPrefs.HasKey("exShield"))
            PlayerPrefs.SetInt("exShield",0);

    }
    public void StoreOpen(){
        storePanel1.SetActive(true);
    }
    public void StoreBack(){
        storePanel1.SetActive(false);
    }
    public void UpgradeButton(){
        storePanel1.SetActive(false);
        storePanel2.SetActive(true);
    }
    public void UpgradeBack(){
        storePanel1.SetActive(true);
        storePanel2.SetActive(false);    
    }
    public void AttackUpgrade(){
        storePanel2.SetActive(false);
        storePanelAttack.SetActive(true);
    }
    public void AttackUpgradeBack(){
        storePanel2.SetActive(true);
        storePanelAttack.SetActive(false);
    }
    public void HealthUpgrade(){
        storePanel2.SetActive(false);
        storePanelHealth.SetActive(true);
    }
    public void HealthUpgradeBack(){
        storePanel2.SetActive(true);
        storePanelHealth.SetActive(false);
    }
    public void ShieldUpgrade(){
        storePanel2.SetActive(false);
        storePanelShield.SetActive(true);
    }
    public void ShieldUpgradeBack(){
        storePanel2.SetActive(true);
        storePanelShield.SetActive(false);
    }
    
}
