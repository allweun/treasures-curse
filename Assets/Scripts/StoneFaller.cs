using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFaller : MonoBehaviour
{
    public GameObject[] stoneTypes;
    public Transform pos1, pos2;
    public Transform character;
    public float offset;
    public Vector3 spawnPoint;
    private int stoneType;
    public float SpawnCooldown;
    private float tempSpawnCooldown;
    public bool startSpawning = false;
    void Start()
    {
        tempSpawnCooldown = SpawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(startSpawning){
            if(tempSpawnCooldown < 0){
                float x=Random.Range(character.position.x+offset,character.position.x-offset);
                spawnPoint = new Vector3(x, pos1.position.y, character.position.z);
                stoneType = Random.Range(0,3);
                Instantiate(stoneTypes[stoneType], spawnPoint, Quaternion.identity);
                tempSpawnCooldown = SpawnCooldown;
            }
        }
        if(tempSpawnCooldown < -2){
            tempSpawnCooldown = -1;
        }
        tempSpawnCooldown -= Time.deltaTime;
    }
}
