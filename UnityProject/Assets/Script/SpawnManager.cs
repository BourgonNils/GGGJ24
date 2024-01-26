using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/*Charg? de faire apparaitre les bulles dans une zone (apparition plus choix de la bulle)  */
public class SpawnManager : MonoBehaviour
{

    [SerializeField] BoxCollider2D zoneToSpawn;
    [SerializeField] GameObject tmp_buble;
    [SerializeField] float spawnBubleEvery = 2f;


    private Player playerOne;
    private Player playerTwo;


    Bounds boundsZoneToSpawn;

    private int playerIdSpawn = 0;

    private float timer;


    private void Start()
    {
        boundsZoneToSpawn = zoneToSpawn.bounds;
        this.playerOne = GameManager.instance.playerOne;
        this.playerTwo = GameManager.instance.playerTwo;
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


  
        int randomIndex = UnityEngine.Random.Range(0,GameManager.instance.correspondanceSprite.Count);
        Symbole cleAleatoire = GameManager.instance.correspondanceSprite.Keys.ElementAt(randomIndex);

        if (playerIdSpawn % 2 == 0)
        {
            bubble.GetComponent<Bubble>().createBubble(cleAleatoire, playerOne.myColorBubble);
        }
        else
        {
            bubble.GetComponent<Bubble>().createBubble(cleAleatoire, playerTwo.myColorBubble);
        }

        playerIdSpawn++;
        

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
