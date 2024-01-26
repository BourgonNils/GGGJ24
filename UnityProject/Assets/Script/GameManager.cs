using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public static GameManager instance;

    public int score = 50;

    public Player playerOne;
    public Player playerTwo;


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
