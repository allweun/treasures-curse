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

    void Start()
    {
        xmax = cameraEX.XMaxVal;
        xmin = cameraEX.XMinVal;
    }
    public void OnTriggerEnter2D(Collider2D colliderTag)
    {
        if (!colliderTag.CompareTag("Character"))
            return;
        cameraEX.XMaxVal = kilitx;
        cameraEX.XMinVal = kilitxMin;
        StartCoroutine(WaitRoutine());
    }
    private IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(beklemeSuresi);
        cameraEX.XMaxVal = xmax;
        cameraEX.XMinVal = xmin;
    }

}
