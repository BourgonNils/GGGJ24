using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int life = 6;
    public int playerId = 0;
    public ColorBubble myColorBubble;


    // Start is called before the first frame update
    void Start()
    {
       if(myColorBubble != ColorBubble.ROUGE && myColorBubble != ColorBubble.BLEU)
            throw new System.Exception("Couleur de joueur non valide");
    }

    public ColorBubble GetColorBubble() 
    { 
        return myColorBubble; 
    }
    public bool Laught()
    {
        this.life--;
        return this.life == 0;
    }


    void OnHaut()
    {
        InputManager.instance.onInput(this, Direction.HAUT);
    }
    
    void OnBas()
    {
        InputManager.instance.onInput(this, Direction.BAS);
    }

    void OnGauche()
    {
        InputManager.instance.onInput(this, Direction.GAUCHE);
    }

    void OnDroite()
    {
        InputManager.instance.onInput(this, Direction.DROITE);
    }
}
