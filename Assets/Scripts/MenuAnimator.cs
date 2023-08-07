using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    public Animator animator;
    public GameObject button;
    public GameObject mainpanel;

    public void TapAnim(){
        animator.SetTrigger("tap");
        button.SetActive(false);
        mainpanel.SetActive(true);
    }
    public void AutoAnim(){
        animator.SetTrigger("auto");
    }
    public void BackAnim(){
        animator.SetTrigger("trigger");
    }
    
    public void Dummy(){}
}
