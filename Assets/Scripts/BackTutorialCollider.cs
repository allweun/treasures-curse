using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTutorialCollider : MonoBehaviour
{
    public Transform nextPos;
    private Vector3 nextPOS;
    public Transform player;
    public TutorialManager tutorial;
    public CameraEX cameraEX;
    public bool teleported=false;
    void Start()
    {
           nextPOS=nextPos.position;
    }
    void OnTriggerEnter2D(Collider2D tag){
        if(tutorial.tutorialNext)
        if(tag.CompareTag("Character")){
            player.position= nextPOS;
            teleported=true;
            cameraEX.YMaxEnabled=true;
            cameraEX.YMinEnabled=true;
        }
    }
}
