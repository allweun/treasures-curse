using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestAnim : MonoBehaviour
{
    public Animator animator;
    public void Chest(){
        animator.SetTrigger("GO");
    }
}
