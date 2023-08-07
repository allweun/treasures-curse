using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    public Animator animator;
    public TutorialManager tutorial;
    public void TeleportEnd(){
        animator.SetTrigger("GeCeAteSiDüzCeSakarYa");
        StartCoroutine(FinishTutorial());
    }
    public IEnumerator FinishTutorial(){
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("tutorial",0);
        SceneManager.LoadScene("Level-1");
    }
}
