using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    public Dictionary<Direction, Symbole> correspondanceDirection = new Dictionary<Direction, Symbole>();

    public int costMissInput = 3;

    private List<Bubble> allBubbles = new List<Bubble>();
    private List<Ballon> allBallons = new List<Ballon>();
    bool isListeningToInput = false;
    [SerializeField] private List<AudioClip> pops_TODELETE;


    public delegate void InputPlayer(Player player, Direction dir);
    public static event InputPlayer onInputPlayer;



    private void Awake()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        this.randomizeSymbole();
    }


    private void Update()
    {
      
    }


    /*Appel? par le joueur*/
    public void onInput(Player player, Direction dir)
    {
        if (!isListeningToInput)
            return;

        onInputPlayer?.Invoke(player, dir);
        GameManager.instance.looseScore(player, costMissInput);
     /*   this.detecteBubble(player, dir);
        this.detecteBallon(player, dir);*/

    }

    /*private void  detecteBubble(Player player, Direction dir) {
        bool bubbleExploded = false;
        foreach (Bubble bubble in allBubbles)
        {
            bubbleExploded = bubble.receiveInput(player, dir);
            if (bubbleExploded)
            {
                GameManager.instance.gainScore(player, this.score);
                int rand = UnityEngine.Random.Range(0, pops.Count - 1);
                AudioSource effect = GetComponent<AudioSource>();
                effect.clip = pops[rand];
                effect.Play();
                Debug.Log(rand);
            }
        }
        if (!bubbleExploded)
            this.misinput(player);
    }*/

/*    private void detecteBallon(Player player, Direction dir)
    {
        bool balloonExploded = false;

        foreach (Ballon ballon in allBallons)
        {
            balloonExploded = ballon.receiveInput(player, dir);
            if (balloonExploded)
            {
                GameManager.instance.gainScore(player, this.score);
            }
        }
        if (!balloonExploded)
            this.misinput(player);
    }
*/
    void misinput(Player player)
    {
        /*Faire perdre des points au joueur en question*/
        Debug.Log(player.name + " miss input");
        GameManager.instance.looseScore(player, costMissInput);

    }
    
    public void addBubble(Bubble newBubble)
    {
        this.allBubbles.Add(newBubble);
    }

    public void removeBubble(Bubble bubbleToRemove)
    {
        this.allBubbles.Remove(bubbleToRemove);
    }

    public void addBallon(Ballon newBallon)
    {
        this.allBallons.Add(newBallon);
    }

    public void removeBallon(Ballon ballonToRemove)
    {
        this.allBallons.Remove(ballonToRemove);
    }

    public void setListeningToInput(bool shouldListen)
    {
        isListeningToInput = shouldListen;
    }

    public void randomizeSymbole() {

        List<Symbole> symboles = ((Symbole[])Enum.GetValues(typeof(Symbole))).ToList();
        List<Direction> directions = ((Direction[]) Enum.GetValues(typeof(Direction))).ToList();


        this.correspondanceDirection.Clear();

        foreach(var direction in directions)
        {
            Symbole addedSymbole = this.getRandomSymbole(symboles);
            symboles.Remove(addedSymbole);
            correspondanceDirection.Add(direction,addedSymbole);
        }

    }

    public void onEndRound()
    {
        GameObject[] symboles = GameObject.FindGameObjectsWithTag("symbole");
        foreach(var symbole in symboles)
        {
            Destroy(symbole);
        }
        allBubbles.Clear();
        isListeningToInput = false;
    }

    private Symbole getRandomSymbole(List<Symbole> symboles)
    {
        System.Random rand = new System.Random();
        int randomIndex = rand.Next(symboles.Count);

        return  symboles.ElementAt(randomIndex);
    }
}
