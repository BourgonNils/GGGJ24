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

    float percentErrosion = 0;
    float maxErrosion = 40;
    float valueErroded = 0 ;



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
        if (mySlider == null)
            throw new System.Exception("Pas de barre de rire ?");
    }

    public int getScore()
    {
        return this.score;
    }

    // Update is called once per frame
    void Update()
    {
        this.addErrosion( 0.0003f * Time.deltaTime); 
    }

    void addErrosion(float newErrosion)
    {
        
        if (newErrosion >1 || newErrosion < 0 )
            throw new System.Exception("Doit être compris entre 0 et 1");

        this.percentErrosion += newErrosion;

        if (percentErrosion > 1)
            percentErrosion = 1;

        valueErroded = maxErrosion * this.percentErrosion;
        mySlider.updateErrosion(valueErroded);
    }

    void onUpdateScore()
    {
        bool endGame = false;
        if (this.score <= (0 +valueErroded))
        {
            endGame = this.playerOne.Laught();
            this.score = 50;
        }
        else if(this.score >= 100 - valueErroded){
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
