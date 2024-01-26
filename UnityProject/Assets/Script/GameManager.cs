using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public static GameManager instance;

    int score = 50;

    public Player playerOne;
    public Player playerTwo;

    public Dictionary<Direction, Symbole> correspondance =
        new Dictionary<Direction, Symbole>(){ 
        {Direction.HAUT, Symbole.PROUT },
        {Direction.BAS, Symbole.SOURIRE },
        {Direction.GAUCHE, Symbole.PLUME },
        {Direction.DROITE, Symbole.BANANE },
};


    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getScore()
    {
        return this.score;
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void UpdateScore(Player player,int score)
    {
        this.score += score;

        bool endGame = false;


        if(this.score <= 0)
        {
            endGame = this.playerOne.Laught();
            this.score = 50;
        }else if(this.score >= 100){
            endGame = this.playerTwo.Laught();
            this.score = 50;
        }



        if (endGame)
            this.endParty();
     
    }



    private void endParty()
    {
        //fin de la parti
    }
}
