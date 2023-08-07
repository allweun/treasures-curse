using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Transform character, posChestPoint, posBack;
    public GameObject nextTutorial;
    public Vector3 RespawnNextTutorial, posChest, posBackDoor;
    public CameraEX cameraEX;
    public GameObject controllerUI;
    public Controller controller;
    public bool ChespStopper;
    public Animator chestAnimator;
    public Collider2D colliderDoor;
    public StoneFaller faller;


    [Header ("TEXT")]
    public Image textbox;
    public Image charFace;
    public Image mageFace;
    public Text[] texts;
    public Button button;

    private bool mage=true;
    private int i=0;

    public mageScript MagePlayer;

    private string[] dialogs=new string[] {"-HOW DARE YOU TOUCH MY TREASURE,MORTAL!",
     "-WHATS THAT VOICE??",//CHAR
     "-WHO YOU ARE?",
     "-IM THE TREASURE HUNTER WHO CAME FROM DISTANT LAND FOR THE TREASURE OF THE GRAND MAGE",//CHAR
     " SO WHO YOU ARE?",
     "-IM A MAGE WHO BOUND THE THIS TREASURE BY DARK SPELL..",
     "-WHAT SPELL??",//CHAR
     "-I CAME HERE CENTURIES AGO... TO STEAL THIS TREASURE FROM THE GRAND MAGE.",
     " I WAS ALMOST DID IT BUT GRAND MAGE CURSED ME..."," AND BOUND MY EXISTENCE TO THIS TREASURE",
     " BECAUSE OF THAT TREASURE STAYS HERE, WITH ME!",
     "-I CAME FROM DISTANT LANDS FOR THIS. DO NOT INTEND TO GO WITHOUT TAKING IT",//CHAR
     "-YOU CAN NOT..."," TAKE IT..."," FROM ME!!!",
     "-OHH. NOO!!",""};
     


    public bool chestOpened=true;
    public bool tutorialNext=false;
    public BackTutorialCollider backTutorial;
    public bool ykilit;
    public bool tutorialEnd;
    public bool buyucugeldimi=false;
    public GameObject moveText;

    void Start(){
        RespawnNextTutorial=nextTutorial.transform.position;
        posChest=posChestPoint.position;
        posBackDoor=posBack.position;
        moveText.SetActive(true);
        StartCoroutine(MoveCor());
    }
    public IEnumerator MoveCor(){yield return new WaitForSeconds(3); moveText.SetActive(false);}
    void OnTriggerEnter2D(Collider2D tag)  {
        if(tag.CompareTag("Character")){
            character.position=RespawnNextTutorial;
            controllerUI.SetActive(false);
            OpenChest();
        }
    }

    void Update(){
        //Debug.Log(Mathf.Abs((character.position.x-posChest.x)));
        float distance = Mathf.Abs((character.position.x-posChest.x));
        if(ChespStopper)
        if(distance<0.3){
            controller.Stop();
            ChespStopper=false;
            ChestOpenning();
        }
        if(colliderDoor.CompareTag("Character")){
            cameraEX.XMaxEnabled=true;
            cameraEX.XMaxVal=-20;
            cameraEX.XMinVal=-19;
        }
        if(!chestOpened){
            if(colliderDoor.CompareTag("Character")){
                cameraEX.XMaxEnabled=false;
            }
        }
        if(backTutorial.teleported){
            controller.Stop();
            cameraEX.XMaxEnabled=false;
            cameraEX.XMinVal=70;
            if(!buyucugeldimi)
            controllerUI.SetActive(true);
            ykilit=true;
            backTutorial.teleported=false;
        }
        if(ykilit){
            cameraEX.YMinEnabled=true;
            cameraEX.YMaxEnabled=true;
        }
        if(tutorialEnd){
        controllerUI.SetActive(false);
        if(!buyucugeldimi){
            MagePlayer.Flip();
            buyucugeldimi=true;
        }
        }
         
    }
    void OpenChest(){
        ChespStopper=true;
        character.position = Vector3.MoveTowards(character.position,posChest,8*Time.deltaTime);
        
    }
    void ChestOpenning(){
        chestAnimator.SetTrigger("closedend");
        StartCoroutine("WaitTime");
    }

    public IEnumerator WaitTime(){
        yield return new WaitForSeconds(2);
        textbox.gameObject.SetActive(true);
        Continue();
    }
    public IEnumerator LastTextTime(float a){
        yield return new WaitForSeconds(a);
        LastText();
    }
    public void MageText(int a){
        textbox.gameObject.SetActive(true);
        texts[0].gameObject.SetActive(true);
        mageFace.gameObject.SetActive(true);
        texts[0].text=dialogs[a];                
    }public void CharText(int a){
        texts[1].gameObject.SetActive(true);
        charFace.gameObject.SetActive(true);
        texts[1].text=dialogs[a];
    }
    
    public void Continue(){
        mageFace.gameObject.SetActive(false);
        charFace.gameObject.SetActive(false);
        texts[0].gameObject.SetActive(false);
        texts[1].gameObject.SetActive(false);
        
        if(mage){
            switch (i)
            {
                case 0:
                    MageText(i);
                    i++;
                    mage=false;
                    break;
                case 2:
                    MageText(i);
                    MagePlayer.MageEndPos();
                    i++;
                    mage=false;
                    break;
                case 5:
                    MageText(i);
                    i++;
                    mage=false;
                    break;
                case 7:
                    MageText(i);
                    i++;
                    break;
                case 8:
                    MageText(i);
                    i++;
                    break;
                case 9:
                    MageText(i);
                    i++;
                    break;
                case 10:
                    MageText(i);
                    i++;
                    mage=false;
                    break;
                case 12:
                    MageText(i);
                    i++;
                    break;
                case 13:
                    MageText(i);
                    i++;
                    MagePlayer.StartMagic();
                    cameraEX.shake=true;
                    faller.startSpawning = true;
                    break;
                case 14:
                    MageText(i);
                    i++;
                    mage=false;
                    break;                    
            }
        }else{
            switch (i)
            {
                case 1:
                    CharText(i);
                    i++;
                    mage=true;
                    MagePlayer.GetMage();
                    break;
                case 3:
                    CharText(i);
                    i++;
                    MagePlayer.EndMark();
                    break;
                case 4:
                    CharText(i);
                    i++;
                    mage=true;
                    break;
                case 6:
                    CharText(i);
                    i++;
                    mage=true;
                    break;
                case 11:
                    CharText(i);
                    i++;
                    mage=true;
                    break;
                case 15:
                    CharText(i);
                    i++;
                    StartCoroutine(LastTextTime(0.5f));
                    break;  
                
            }
        }
    }
    public void LastText(){
        textbox.gameObject.SetActive(false);
        mageFace.gameObject.SetActive(false);
        charFace.gameObject.SetActive(false);
        texts[0].gameObject.SetActive(false);
        texts[1].gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        BackMove();
    }
    public void BackMove(){
        tutorialNext=true;
        chestOpened=false;
        ChespStopper=false;
        controller.Right();
        character.position = Vector3.MoveTowards(character.position,posBackDoor,8*Time.deltaTime);
        ykilit=true;
    }


}
