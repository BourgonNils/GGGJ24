using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    List<Bubble> allBubbles = new List<Bubble>();

    private void Awake()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }


    /*Appelé par le joueur*/
    void onInput(int numeroJoueur, Direction dir)
    {
        if (numeroJoueur < 1 || numeroJoueur > 2)
            throw new System.Exception("Num joueur invalide ");

        bool bubbleExploded = false;
        foreach(Bubble bubble in allBubbles)
        { 
            bubbleExploded = bubble.receiveInput(numeroJoueur, dir);
            if (bubbleExploded)
                return;
        }
        this.misinput(numeroJoueur);
    }
    
    void misinput(int numeroJoueur)
    {
        /*Faire perdre des points au joueur en question*/
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
