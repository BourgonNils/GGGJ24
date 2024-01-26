using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;


    private int score = 10;


    List<Bubble> allBubbles = new List<Bubble>();

    private void Awake()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
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

}
