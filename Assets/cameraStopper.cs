using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraStopper : MonoBehaviour
{
    public CameraEX cameraEX;
    public float kilitx;
    public float kilitxMin;
    private float xmax;
    private float xmin;
    public float beklemeSuresi;

    void Start(){
        xmax=cameraEX.XMaxVal;
        xmin=cameraEX.XMinVal;
    }
    public void OnTriggerEnter2D(Collider2D tag){
        if(tag.CompareTag("Character"))
        {
            cameraEX.XMaxVal=kilitx;
            cameraEX.XMinVal=kilitxMin;
            StartCoroutine(Bekleme());
        }
    }
    public IEnumerator Bekleme(){
        yield return new WaitForSeconds(beklemeSuresi);
        cameraEX.XMaxVal=xmax;
        cameraEX.XMinVal=xmin;
    }

}
