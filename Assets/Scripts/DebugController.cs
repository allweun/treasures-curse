using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    public Controller controller;
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            controller.Right();
        } 
        if(Input.GetKey(KeyCode.LeftArrow)){
            controller.Left();
        }
        if(Input.GetKey(KeyCode.Space)){
            character.Jump();
        }
        if(Input.GetKey(KeyCode.C)){
            character.Attack();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)){
            controller.Stop();
        }
    }
}
