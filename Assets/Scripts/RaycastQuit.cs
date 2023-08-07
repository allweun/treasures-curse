using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RaycastQuit : MonoBehaviour
{
    public GameObject QuitPanel;
    public bool active=false;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!active){
            QuitPanel.SetActive(true);
            active=true;            
        }else{
            QuitPanel.SetActive(false);
            active=false;
        }}
    }   
}
