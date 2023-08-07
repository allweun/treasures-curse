using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBuyMech : MonoBehaviour
{
    public Button[] HealthLevel;
    public Image[] Solded;
    public int[] HpLevelValues;
    private int MoneyAmount;
    private int exHealth=0;
    public Text ctext;
    public Image[] Lock;
    public bool[] sold;
    private string prefAttack="prefHealth";
    public Text[] valueText;
    void Start()
    {
        //PlayerPrefs.DeleteKey("hpLevel");
        exHealth=PlayerPrefs.GetInt("exHealth");
        MoneyAmount=PlayerPrefs.GetInt("coins");
        if(!PlayerPrefs.HasKey("hpLevel"))
            PlayerPrefs.SetInt("hpLevel",0);
        for (int i = 0; i < sold.Length; i++)
        {
            bool a = false;
            string TempPrefAttack=prefAttack+i.ToString();
            if(PlayerPrefs.GetInt(TempPrefAttack) == 1){
                a = true;
            }else{
                a = false;
            }
            sold[i] = a;
        }
        for (int i = 0; i < HpLevelValues.Length ; i++)
        {
            valueText[i].text=HpLevelValues[i].ToString();
        }
        ctext.text=PlayerPrefs.GetInt("coins").ToString();
    }
    void Update()
    {
        for (int i = 0; i < sold.Length; i++)
        {   int a=0;
            string TempPrefAttack=prefAttack+i.ToString();
            if(sold[i]==true){
                a=1;
            }else   {a=0;}
            PlayerPrefs.SetInt(TempPrefAttack,a);
        }
        for (int i = 0; i < HealthLevel.Length; i++)
        {
            if(sold[i]==true){
                Solded[i].gameObject.SetActive(true);
                Lock[i].gameObject.SetActive(false);
            }else{
                Lock[i].gameObject.SetActive(true);
                Solded[i].gameObject.SetActive(false);
            }
        }
        if(PlayerPrefs.GetInt("hpLevel")==0){
            if(MoneyAmount>=HpLevelValues[0]){
                HealthLevel[0].interactable=true;
                Lock[0].gameObject.SetActive(false);
        }}if(PlayerPrefs.GetInt("hpLevel")==1){
            if(MoneyAmount>=HpLevelValues[1]){
                HealthLevel[1].interactable=true;
                Lock[1].gameObject.SetActive(false);
            }
        }if(PlayerPrefs.GetInt("hpLevel")==2){
            if(MoneyAmount>=HpLevelValues[2]){
                HealthLevel[2].interactable=true;
                Lock[2].gameObject.SetActive(false);
            }
        }if(PlayerPrefs.GetInt("hpLevel")==3){
            if(MoneyAmount>=HpLevelValues[3]){
                HealthLevel[3].interactable=true;
                Lock[3].gameObject.SetActive(false);
            }
        }if(PlayerPrefs.GetInt("hpLevel")==4){
            if(MoneyAmount>=HpLevelValues[4]){
                HealthLevel[4].interactable=true;
                Lock[4].gameObject.SetActive(false);
            }
        }
        // for (int i = 0; i < HealthLevel.Length; i++)
        // {
        //     if(HealthLevel[i].interactable==false)
        //         Lock[i].gameObject.SetActive(true);
        //     else
        //         Lock[i].gameObject.SetActive(false);
        // }
        PlayerPrefs.SetInt("coins",MoneyAmount);
        PlayerPrefs.SetInt("exHealth",exHealth);
        ctext.text=PlayerPrefs.GetInt("coins").ToString();
    }

    public void SoldLevel(int levelNum){
        if(levelNum==1){
            if(PlayerPrefs.GetInt("hpLevel")==0){
                HealthLevel[0].interactable=false;
                Lock[0].gameObject.SetActive(false);
                Solded[0].gameObject.SetActive(true);
                MoneyAmount-=HpLevelValues[0];
                exHealth+=10;
                PlayerPrefs.SetInt("hpLevel",1);
                sold[0]=true;
            }
        }
        if(levelNum==2){
            if(PlayerPrefs.GetInt("hpLevel")==1){
                HealthLevel[1].interactable=false;
                Lock[1].gameObject.SetActive(false);
                Solded[1].gameObject.SetActive(true);
                MoneyAmount-=HpLevelValues[1];
                exHealth+=10;
                PlayerPrefs.SetInt("hpLevel",2);
                sold[1]=true;
            }
        }
        if(levelNum==3){
            if(PlayerPrefs.GetInt("hpLevel")==2){
                HealthLevel[2].interactable=false;
                Lock[2].gameObject.SetActive(false);
                Solded[2].gameObject.SetActive(true);
                MoneyAmount-=HpLevelValues[2];
                exHealth+=10;
                PlayerPrefs.SetInt("hpLevel",3);
                sold[2]=true;
            }
        }
        if(levelNum==4){
            if(PlayerPrefs.GetInt("hpLevel")==3){
                HealthLevel[3].interactable=false;
                Lock[3].gameObject.SetActive(false);
                Solded[3].gameObject.SetActive(true);
                MoneyAmount-=HpLevelValues[3];
                exHealth+=10;
                PlayerPrefs.SetInt("hpLevel",4);
                sold[3]=true;
            }
        }
        if(levelNum==5){
            if(PlayerPrefs.GetInt("hpLevel")==4){
                HealthLevel[4].interactable=false;
                Lock[4].gameObject.SetActive(false);
                Solded[4].gameObject.SetActive(true);
                MoneyAmount-=HpLevelValues[4];
                exHealth+=10;
                PlayerPrefs.SetInt("hpLevel",5);
                sold[4]=true;
            }
        }
    }
}
