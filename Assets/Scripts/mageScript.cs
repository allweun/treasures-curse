using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mageScript : MonoBehaviour
{
    public Animator animator;
    public Transform magePos, goPosObj, endPosObj, endPortalPosObj, PlayerPosObj, portal2Obj;
    private Vector3 goPos, endPos, endPortalPos, PlayerPos, portal2;  
    public TutorialManager tutorial;
    private bool geldimAQ = false;
    private bool gotoPos=false;
    public GameObject Endtextbox;
    public Text textEnd;
    public bool magetext = false;
    private float textTimer = 0;
    private string[] endTexts = {"-YOU SHOULD NOT HAVE INVESTIGATE THE TREASURE...",
                                "-YOU ARE CURSED BY THE TREASURE..",
                                "-YOU WILL BE PUNISHED!"};


    public Animator portal;


    
    void Start(){
        goPos=goPosObj.position;
        endPortalPos = endPortalPosObj.position;
        endPos = endPosObj.position;
        Endtextbox.SetActive(false);
    }
    void Update(){
        PlayerPos = PlayerPosObj.position;
        portal2 = portal2Obj.position;
        if(gotoPos){
            if(!geldimAQ){
                magePos.position = Vector3.MoveTowards(magePos.position,goPos,6*Time.deltaTime);    
            }
        }
        if(tutorial.buyucugeldimi){
            if(!geldimAQ){
            magePos.position = endPos;
            animator.SetTrigger("endMagic");
            geldimAQ = true;
            }
        }
        if(geldimAQ){
            //sona yürüt
            magePos.position = Vector3.MoveTowards(magePos.position, endPortalPos, 6*Time.deltaTime);
        }
        if(Mathf.Abs(magePos.position.x - endPortalPos.x) < 0.3){
            //indi
            StartCoroutine(SondaBekle());
        }
        if(!magetext)
            Endtextbox.SetActive(false);

        if(magetext){
            textTimer += Time.deltaTime;
            if(textTimer > 1.5){
                Endtextbox.SetActive(true);
                textEnd.text = endTexts[0];
            }
            if(textTimer > 3)
                textEnd.text = endTexts[1];
            if(textTimer > 4.5)
                textEnd.text = endTexts[2];
            if(textTimer > 6){
                magetext = false;
                Endtextbox.SetActive(false);
                portal2Obj.position = new Vector3(PlayerPos.x,PlayerPos.y,PlayerPos.z);
                portal.SetTrigger("yaraliQeQe81");
            }
        }
        
    }
    public IEnumerator SondaBekle(){
        yield return new WaitForSeconds(0.3f);
        animator.SetTrigger("magic");
        magetext = true;
    }
    public void StartMagic(){
        animator.SetTrigger("magic");
    }
    public void Magic2(){
        animator.SetTrigger("magic2");
    }
    public void EndMagic(){
        animator.SetTrigger("endMagic");
    }
    public void BacktoIdle(){
        animator.SetTrigger("backtoIdle");
    }
    public void StartMark(){
        animator.SetTrigger("mark");
    }
    public void Mark2(){
        animator.SetTrigger("mark2");
    }
    public void EndMark(){
        animator.SetTrigger("endmark");
    }
    public void GetMage(){
        gotoPos=true;
        Mark2();
    }
    public void MageEndPos(){
        magePos.position=new Vector3 (goPos.x,goPos.y,goPos.z);
        StartMark();
    }
    public void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
     
}
