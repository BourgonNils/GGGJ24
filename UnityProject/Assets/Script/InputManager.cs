using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    public Dictionary<Direction, Symbole> correspondanceDirection = new Dictionary<Direction, Symbole>();

    private int score = 10;
    private List<Bubble> allBubbles = new List<Bubble>();

    private void Awake()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        this.randomizeSymbole();
    }


    /*Appel? par le joueur*/
    public void onInput(Player player, Direction dir)
    {
        bool bubbleExploded = false;
        foreach(Bubble bubble in allBubbles)
        { 
            bubbleExploded = bubble.receiveInput(player, dir);
            if (bubbleExploded)
            {
                Debug.Log(player.name + " " + dir);
                GameManager.instance.gainScore(player, this.score);
                return;
            }
        }
        this.misinput(player);
    }
    
    void misinput(Player player)
    {
        /*Faire perdre des points au joueur en question*/
        Debug.Log(player.name + " miss input");
        GameManager.instance.looseScore(player, score);

    }
    
    public void addBubble(Bubble newBubble)
    {
        this.allBubbles.Add(newBubble);
    }

    public void removeBubble(Bubble bubbleToRemove)
    {
        this.allBubbles.Remove(bubbleToRemove);
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

    private Symbole getRandomSymbole(List<Symbole> symboles)
    {
        System.Random rand = new System.Random();
        int randomIndex = rand.Next(symboles.Count);

        return  symboles.ElementAt(randomIndex);
    }
}
