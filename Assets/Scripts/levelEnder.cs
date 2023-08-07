using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnder : MonoBehaviour
{
    public string LevelName;
    public void EndedLevel(){
        PlayerPrefs.SetInt(LevelName,1);
    }
}
