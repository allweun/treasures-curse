using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelUIScript : MonoBehaviour
{
    public int levelNum;
    public int fullChest;
    public int fullCoin;
    public string sure;
    public Character character;
    public Chest chest;
    public Image stars;
    public Text chestCount;
    public Text CoinCount;
    public Text timeCount;
    public TimeManager timeManager;
    
    void Start()
    {
        stars.fillAmount=0;
        if(levelNum==1){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<1){
                if(timeManager.second<=20)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==2){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<1){
                if(timeManager.second<=45)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==3){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<1){
                if(timeManager.second<=59)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==4){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<1){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==1){
                if(timeManager.second<=5)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==5){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<2){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==2){
                if(timeManager.second<=0)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==6){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<2){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==2){
                if(timeManager.second<=40)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==7){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<3){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==3){
                if(timeManager.second==0)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==8){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<3){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==3){
                if(timeManager.second<=20)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==9){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<4){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==4){
                if(timeManager.second<=20)
                    stars.fillAmount+=0.25f;
            }
        }if(levelNum==10){
            chestCount.text=chest.a.ToString()+"/"+fullChest.ToString();
            CoinCount.text=character.levelCoins.ToString()+"/"+fullCoin.ToString();
            timeCount.text=timeManager.sure+"/"+sure;
            stars.fillAmount=0.25f;
            if(chest.a==fullChest){
                stars.fillAmount+=0.25f;
            }
            if(character.levelCoins>=fullCoin){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute<4){
                stars.fillAmount+=0.25f;
            }
            if(timeManager.minute==4)
                if(timeManager.second<=30){
                    stars.fillAmount+=0.25f;
            }
        }
    }
}
