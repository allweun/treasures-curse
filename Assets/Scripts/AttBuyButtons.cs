using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttBuyButtons : MonoBehaviour
{
    public Button[] AttackLevel;
    public Image[] Solded;
    public int[] AttackLevelValues;
    private int MoneyAmount;
    private int ExDamage=0;
    public Text ctext;
    public Image[] Lock;
    public bool[] sold;
    private string prefAttack="prefAttack";

    public Text[] valueText;
    
    
    void Start()
    {
        //PlayerPrefs.DeleteKey("attackLevel");
        ExDamage=PlayerPrefs.GetInt("exDamage");
        MoneyAmount=PlayerPrefs.GetInt("coins");
        if(!PlayerPrefs.HasKey("attackLevel"))
            PlayerPrefs.SetInt("attackLevel",0);
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
        
        ctext.text=PlayerPrefs.GetInt("coins").ToString();
        for (int i = 0; i < AttackLevelValues.Length ; i++)
        {
            valueText[i].text=AttackLevelValues[i].ToString();
        }
    }

    // Update is called once per frame
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
        for (int i = 0; i < AttackLevel.Length; i++)
        {
            if(sold[i]==true){
                Solded[i].gameObject.SetActive(true);
                Lock[i].gameObject.SetActive(false);
            }else{
                Lock[i].gameObject.SetActive(true);
                Solded[i].gameObject.SetActive(false);
            }
        }
        if(PlayerPrefs.GetInt("attackLevel")==0){
            if(MoneyAmount>=AttackLevelValues[0]){
                AttackLevel[0].interactable=true;
                Lock[0].gameObject.SetActive(false);
        }}if(PlayerPrefs.GetInt("attackLevel")==1){
            if(MoneyAmount>=AttackLevelValues[1]){
                AttackLevel[1].interactable=true;
                Lock[1].gameObject.SetActive(false);
            }
        }if(PlayerPrefs.GetInt("attackLevel")==2){
            if(MoneyAmount>=AttackLevelValues[2]){
                AttackLevel[2].interactable=true;
                Lock[2].gameObject.SetActive(false);
            }
        }if(PlayerPrefs.GetInt("attackLevel")==3){
            if(MoneyAmount>=AttackLevelValues[3]){
                AttackLevel[3].interactable=true;
                Lock[3].gameObject.SetActive(false);
            }
        }if(PlayerPrefs.GetInt("attackLevel")==4){
            if(MoneyAmount>=AttackLevelValues[4]){
                AttackLevel[4].interactable=true;
                Lock[4].gameObject.SetActive(false);
            }
        }
        
        PlayerPrefs.SetInt("coins",MoneyAmount);
        PlayerPrefs.SetInt("exDamage",ExDamage);
        ctext.text=PlayerPrefs.GetInt("coins").ToString();
    }
    public void SoldLevel(int levelNum){
        if(levelNum==1){
            if(PlayerPrefs.GetInt("attackLevel")==0){
                AttackLevel[0].interactable=false;
                Lock[0].gameObject.SetActive(false);
                Solded[0].gameObject.SetActive(true);
                MoneyAmount-=AttackLevelValues[0];
                ExDamage+=10;
                PlayerPrefs.SetInt("attackLevel",1);
                sold[0]=true;
            }
        }
        if(levelNum==2){
            if(PlayerPrefs.GetInt("attackLevel")==1){
                AttackLevel[1].interactable=false;
                Lock[1].gameObject.SetActive(false);
                Solded[1].gameObject.SetActive(true);
                MoneyAmount-=AttackLevelValues[1];
                ExDamage+=10;
                PlayerPrefs.SetInt("attackLevel",2);
                sold[1]=true;
            }
        }
        if(levelNum==3){
            if(PlayerPrefs.GetInt("attackLevel")==2){
                AttackLevel[2].interactable=false;
                Lock[2].gameObject.SetActive(false);
                Solded[2].gameObject.SetActive(true);
                MoneyAmount-=AttackLevelValues[2];
                ExDamage+=10;
                PlayerPrefs.SetInt("attackLevel",3);
                sold[2]=true;
            }
        }
        if(levelNum==4){
            if(PlayerPrefs.GetInt("attackLevel")==3){
                AttackLevel[3].interactable=false;
                Lock[3].gameObject.SetActive(false);
                Solded[3].gameObject.SetActive(true);
                MoneyAmount-=AttackLevelValues[3];
                ExDamage+=10;
                PlayerPrefs.SetInt("attackLevel",4);
                sold[3]=true;
            }
        }
        if(levelNum==5){
            if(PlayerPrefs.GetInt("attackLevel")==4){
                AttackLevel[4].interactable=false;
                Lock[4].gameObject.SetActive(false);
                Solded[4].gameObject.SetActive(true);
                MoneyAmount-=AttackLevelValues[4];
                ExDamage+=10;
                PlayerPrefs.SetInt("attackLevel",5);
                sold[4]=true;
            }
        }
    }
}
