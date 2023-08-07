using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxScales;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1-parallaxScales));
        float dist = (cam.transform.position.x * (parallaxScales));
        transform.position = new Vector3(startPos+dist,transform.position.y,transform.position.z);
        if(temp>startPos +length) startPos+=length;
        else if(temp<startPos-length) startPos-=length;
    }
}
