using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startpos;
    public float distanceBetweenPositions;

    Vector3 nextpos;
    // Start is called before the first frame update
    void Start()
    {
        nextpos = startpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, pos1.position) <= 0.3f){
            nextpos = pos2.position;
        }
        if(Vector2.Distance(transform.position, pos2.position) <= 0.3f){
            nextpos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed*Time.deltaTime);
        distanceBetweenPositions = Mathf.Sqrt(((pos1.position.x - pos2.position.x) * (pos1.position.x - pos2.position.x)) + ((pos1.position.y - pos2.position.y) * (pos1.position.y - pos2.position.y)));
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
