using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int score = 50;

    public Player playerOne;
    public Player playerTwo;
    private BarreDeRire mySlider;

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
        mySlider = FindFirstObjectByType<BarreDeRire>();
    }

    public int getScore()
    {
        return this.score;
    }

    // Update is called once per frame
    void Update()
    {



    }


    void onUpdateScore()
    {
        bool endGame = false;
        if (this.score <= 0)
        {
            endGame = this.playerOne.Laught();
            this.score = 50;
        }
        else if(this.score >= 100){
            endGame = this.playerTwo.Laught();
            this.score = 50;
        }

        mySlider.updateScore(this.score);

        if (endGame)
            this.endParty();
    }

    public void gainScore(Player player,int score)
    {
        if (player == playerOne)
            this.score += score;
        else
            this.score -= score;


        this.onUpdateScore();

        Debug.Log("score" + this.score);
    }


    public void looseScore(Player player,int score)
    {
        this.gainScore(player, -score);
    }



    private void endParty()
    {
        //fin de la parti
    }

  
}
