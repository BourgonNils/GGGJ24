using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/*Charg? de faire apparaitre les bulles dans une zone (apparition plus choix de la bulle)  */
public class SpawnManager : MonoBehaviour
{

    [SerializeField] CorrespondanceSprite correspondanceSprite;
    [SerializeField] BoxCollider2D zoneToSpawn;
    [SerializeField] GameObject tmp_buble;
    [SerializeField] float spawnBubleEvery = 2f;
    [SerializeField] float mixtSpawnRate = 20f;
    [SerializeField] float doubleSpawnRate = 20f;

    bool shouldSpawnBubble = false;
    private Player playerOne;
    private Player playerTwo;


    Bounds boundsZoneToSpawn;

    float minDistanceBetweenBubbles = 1f;
    private int playerIdSpawn = 0;
    private float timer;
    private Vector3 lastSpawnPosition = Vector3.zero;


    private void Start()
    {
        boundsZoneToSpawn = zoneToSpawn.bounds;
        this.playerOne = GameManager.instance.playerOne;
        this.playerTwo = GameManager.instance.playerTwo;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldSpawnBubble)
            return;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = spawnBubleEvery;
            spawnBuble();
        }
    }


    void spawnBuble()
    {
        
  
        int randomIndex = UnityEngine.Random.Range(0,this.correspondanceSprite.count());
        Symbole symbole = this.correspondanceSprite.symboleAtIndex(randomIndex);

        this.lastSpawnPosition = playerIdSpawn % 2 == 0 ? this.testH(symbole, playerOne.myColorBubble) : this.testH(symbole, playerTwo.myColorBubble);

        playerIdSpawn++;


        if (UnityEngine.Random.Range(0, 100) <= doubleSpawnRate)
            this.spawnBuble();


    }

    public Vector3 testH(Symbole symbole,ColorBubble color)
    {
        GameObject bubble = Instantiate(tmp_buble);

        if (UnityEngine.Random.Range(0, 100) <= mixtSpawnRate)
            color = ColorBubble.VIOLET;

        bubble.GetComponent<Bubble>().createBubble(symbole, color);
        Vector3 bubulePosition = this.getRandomPos();
        bubble.transform.position = bubulePosition;

        return bubulePosition;

    }

    public void setSpawnerActive(bool newState) 
    {
        this.shouldSpawnBubble = newState;
    }
    Vector3 getRandomPos()
    {
        Vector3 randomPosition = Vector3.zero;

        int tmp = 0;

        do
        {
            randomPosition = new Vector3(
               UnityEngine.Random.Range(boundsZoneToSpawn.min.x, boundsZoneToSpawn.max.x),
               UnityEngine.Random.Range(boundsZoneToSpawn.min.y, boundsZoneToSpawn.max.y),
               0
            );

            tmp++;

            if (tmp > 100)
                break;
            


        } while (Vector3.Distance(randomPosition, lastSpawnPosition) < minDistanceBetweenBubbles);


        return randomPosition;
    }
}
