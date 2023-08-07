using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Controller : MonoBehaviour
{
    public Character player;
    void Start()
    {
        player = FindObjectOfType<Character>();
    }
    public void Left()
    {
        player.moveleft = true;
        player.moveright = false;
        player.movestop = false;
        player.moveSound = true;
    }
    public void Right()
    {

        player.moveright = true;
        player.moveleft = false;
        player.movestop = false;
        player.moveSound = true;
    }
    public void Stop()
    {
        player.movestop = true;
        player.moveleft = false;
        player.moveright = false;
        player.moveSound = false;
    }
}
