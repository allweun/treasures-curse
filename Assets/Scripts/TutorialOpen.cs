using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialOpen : MonoBehaviour
{
    void Start(){
        //PlayerPrefs.DeleteKey("tutorial");
         if(PlayerPrefs.HasKey("tutorial")==false){
             SceneManager.LoadScene("Tutorial");
             PlayerPrefs.Save();
         }
    }
}
