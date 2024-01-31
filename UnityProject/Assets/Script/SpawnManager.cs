using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/*Charg? de faire apparaitre les bulles dans une zone (apparition plus choix de la bulle)  */
public class SpawnManager : MonoBehaviour
{

    [SerializeField] CorrespondanceSprite correspondanceSprite;
    [SerializeField] BoxCollider2D zoneToSpawn;
    [SerializeField] BoxCollider2D zoneToSpawnBallon;
    [SerializeField] GameObject tmp_buble;
    [SerializeField] GameObject tmp_ballon;
    [SerializeField] float spawnBubleEvery = 2f;
    [SerializeField] float spawMonoColorRate = 20f;

    [SerializeField] float spawVioletRate = 80f;
    [SerializeField] float spawnBallonEvery = 1f;
    [SerializeField] float spawBallonRate = 80f;

    bool shouldSpawnBubble = false;
    private Player playerOne;
    private Player playerTwo;


    Bounds boundsZoneToSpawn;
    Bounds boundsZoneBallon;

    float minDistanceBetweenBubbles = 1f;
    private int playerIdSpawn = 0;
    private float timer;
    private float timerViolet;
    private float timerBallon;
    private float spawnVioletEvry;
    private Vector3 lastSpawnPosition = Vector3.zero;


    private void Start()
    {
        boundsZoneToSpawn = zoneToSpawn.bounds;
        boundsZoneBallon = zoneToSpawnBallon.bounds;
        this.playerOne = GameManager.instance.playerOne;
        this.playerTwo = GameManager.instance.playerTwo;
        this.spawnVioletEvry = this.spawnBubleEvery;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldSpawnBubble)
            return;

        timer -= Time.deltaTime;
        timerViolet -= Time.deltaTime;
        timerBallon -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = spawnBubleEvery  * UnityEngine.Random.Range(0.95f,1.1f);
            spawnBuble();
        }

        if(timerViolet <= 0)
        {
            timerViolet = spawnVioletEvry * UnityEngine.Random.Range(0.95f, 1.1f);
            this.spawnBubbleViolet();
        }

        if (timerBallon <= 0)
        {
            timerBallon = spawnBallonEvery * UnityEngine.Random.Range(0.95f, 1.1f);
            this.spawnBallon();
        }
    }


    void spawnBuble()
    {
        if (UnityEngine.Random.Range(0, 100) >= this.spawMonoColorRate)
            return;

            int randomIndex = UnityEngine.Random.Range(0,this.correspondanceSprite.count());
        Symbole symbole = this.correspondanceSprite.symboleAtIndex(randomIndex);

        this.lastSpawnPosition = playerIdSpawn % 2 == 0 ? this.createBubble(symbole, playerOne.myColorBubble) : this.createBubble(symbole, playerTwo.myColorBubble);

        playerIdSpawn++;
    }

    void spawnBubbleViolet()
    {
        if (UnityEngine.Random.Range(0, 100) >= this.spawVioletRate)
            return;
            int randomIndex = UnityEngine.Random.Range(0, this.correspondanceSprite.count());
            Symbole symbole = this.correspondanceSprite.symboleAtIndex(randomIndex);
            this.createBubble(symbole, ColorBubble.VIOLET);
        
    }

    public Vector3 createBubble(Symbole symbole,ColorBubble color)
    {
        GameObject bubble = Instantiate(tmp_buble);
        bubble.GetComponent<Bubble>().setSymboleAndColor(symbole, color);
        Vector3 bubulePosition = this.getRandomPos();
        bubble.transform.position = bubulePosition;
        return bubulePosition;
    }

    public void spawnBallon()
    {
        if (UnityEngine.Random.Range(0, 100) <= this.spawBallonRate)
        {
            int randomIndex = UnityEngine.Random.Range(0, this.correspondanceSprite.count());
            int randomColor = UnityEngine.Random.Range(0,2);

            ColorBubble color = randomColor == 0 ? playerOne.myColorBubble : playerTwo.myColorBubble;
            Symbole symbole = this.correspondanceSprite.symboleAtIndex(randomIndex);
            GameObject ballon = Instantiate(tmp_ballon);
            ballon.GetComponent<Ballon>().setSymboleAndColor(symbole, color);
            Vector3 ballonPosition = this.randomPosBallon();
            ballon.transform.position = ballonPosition;
        }
    }

    public void setSpawnerActive(bool newState) 
    {
        this.shouldSpawnBubble = newState;
    }

    private Vector3 getRandomPos()
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

    private Vector3 randomPosBallon()
    {
        return new Vector3(
               UnityEngine.Random.Range(boundsZoneBallon.min.x, boundsZoneBallon.max.x),
               UnityEngine.Random.Range(boundsZoneBallon.min.y, boundsZoneBallon.max.y),
               0
            );
    }
}
