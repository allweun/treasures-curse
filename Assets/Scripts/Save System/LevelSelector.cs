using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    public Button[] levels;

    public void Start()
    {
        if(PlayerPrefs.HasKey("level-1")){
            levels[1].interactable=true;
        }
        if(PlayerPrefs.HasKey("level-2")){
            levels[2].interactable=true;
        } 
        if(PlayerPrefs.HasKey("level-3")){
            levels[3].interactable=true;
        }  
        if(PlayerPrefs.HasKey("level-4")){
            levels[4].interactable=true;
        } 
        if(PlayerPrefs.HasKey("level-5")){
            levels[5].interactable=true;
        } 
        if(PlayerPrefs.HasKey("level-6")){
            levels[6].interactable=true;
        } 
        if(PlayerPrefs.HasKey("level-7")){
            levels[7].interactable=true;
        } 
        if(PlayerPrefs.HasKey("level-8")){
            levels[8].interactable=true;
        }
        if(PlayerPrefs.HasKey("level-9")){
            levels[9].interactable=true;
        } 
        // if(PlayerPrefs.HasKey("level-10")){
        //     levels[10].interactable=true;
        // }  
    }

    

}
