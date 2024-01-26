using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*Chargé de faire apparaitre les bulles dans une zone (apparition plus choix de la bulle)  */
public class SpawnManager : MonoBehaviour
{

    [SerializeField] BoxCollider2D zoneToSpawn;
    [SerializeField] GameObject tmp_buble;
    [SerializeField] float spawnBubleEvery = 2f;


    Bounds boundsZoneToSpawn;

    private float timer;


    private void Start()
    {
        boundsZoneToSpawn = zoneToSpawn.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = spawnBubleEvery;
            spawnBuble();
        }
    }


    void spawnBuble()
    {
        GameObject bubble = Instantiate(tmp_buble);

        /*Changer la position de la bulle*/
        bubble.transform.position = getRandomPos();
    }


    Vector3 getRandomPos()
    {
        return new Vector3(
           UnityEngine.Random.Range(boundsZoneToSpawn.min.x, boundsZoneToSpawn.max.x),
           UnityEngine.Random.Range(boundsZoneToSpawn.min.y, boundsZoneToSpawn.max.y),
           UnityEngine.Random.Range(boundsZoneToSpawn.min.z, boundsZoneToSpawn.max.z)
       );
    }
}
