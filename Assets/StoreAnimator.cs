using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAnimator : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Upgrade(){
        animator.SetTrigger("upgrade");
    }

    public void EndUpgrade(){
        animator.SetTrigger("endupgrade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
