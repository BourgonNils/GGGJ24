using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public static GameManager instance;

    int score = 50;

    public Player playerOne;
    public Player playerTwo;

    [SerializeField] Sprite banane;
    [SerializeField] Sprite prout;
    [SerializeField] Sprite plume;
    [SerializeField] Sprite sourire;

    private BarreDeRire mySlider;


    public Dictionary<Direction, Symbole> correspondanceSymbole =
        new Dictionary<Direction, Symbole>(){ 
            {Direction.HAUT, Symbole.PROUT },
            {Direction.BAS, Symbole.SOURIRE },
            {Direction.GAUCHE, Symbole.PLUME },
            {Direction.DROITE, Symbole.BANANE },
         };

    public Dictionary<ColorBubble, Color> correspondanceColor =
      new Dictionary<ColorBubble, Color>(){
            {ColorBubble.ROUGE, Color.red },
            {ColorBubble.BLEU, Color.blue },
            {ColorBubble.NOIR, Color.black },
            {ColorBubble.VIOLET, Color.magenta },
       };

    public Dictionary<Symbole, Sprite> correspondanceSprite;


    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        this.correspondanceSprite =
            new Dictionary<Symbole, Sprite>() {
                {Symbole.BANANE, this.banane},
                {Symbole.PROUT, this.prout},
                {Symbole.PLUME, this.plume},
                {Symbole.SOURIRE, this.sourire},
            };
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
