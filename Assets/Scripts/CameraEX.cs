using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEX : MonoBehaviour
{
    public Transform target;
    Vector3 velocity = Vector3.zero;
    public float smoothTime = .1f;
    public bool YMaxEnabled = false;
    public float YMaxVal = 0f;
    public bool YMinEnabled = false;
    public float YMinVal = 0f;
    public bool XMaxEnabled = false;
    public bool XMinEnabled = false;
    public float XMaxVal = 0;
    public float XMinVal = 0;
    public float charY;

    public bool shake=false;
    public float magnitude;

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        targetPos.y += charY;
        if (YMinEnabled && YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinVal, YMaxVal);
        else if (YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinVal, target.position.y);
        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxVal);

        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinVal, XMaxVal);
        else if (XMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinVal, target.position.x);
        else if (XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxVal);

        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        if(shake){
            magnitude=0.05f;
            YMinEnabled=false;
            XMaxEnabled=false;
            XMinEnabled=true;
            YMaxEnabled=false;
            charY=2;
            StartCoroutine(Shake());
        }    
    }
    public IEnumerator Shake(){
        float x= Random.Range(-1f,1f)*magnitude;
        float y= Random.Range(-1f,1f)*magnitude;
        transform.position +=new Vector3 (x,y,0);
        yield return new WaitForSeconds(.01f);
        transform.position -= new Vector3(x,y,0);
        yield return new WaitForSeconds(.01f);
    }
    
    
}
