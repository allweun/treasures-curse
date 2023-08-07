using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour
{
    public SettingsMenu settings;
    public GameObject pauseMenu;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(settings.ReturnPause()){
                settings.Resume();
                pauseMenu.SetActive(false);
            }else{
                settings.Pause();
                pauseMenu.SetActive(true);
            }
        }
    }
}
