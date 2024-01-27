using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int score = 50;

    public Player playerOne;
    public Player playerTwo;
    [SerializeField] BarreDeRire mySlider;


    float percentErrosion = 0;
    float maxErrosion = 40;
    float valueErroded = 0;

    List<ListenerGameEvent> listeners = new List<ListenerGameEvent>();
    public enum GameEvent { ENDROUND,GAMEOVER, STARTGAME};

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
        if (mySlider == null)
            throw new System.Exception("Pas de barre de rire ?");
        notifyListeners(GameEvent.STARTGAME);
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
            resetRound();
        }
        else if(this.score >= 100 - valueErroded){
            endGame = this.playerTwo.Laught();
            resetRound();
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

    void resetRound()
    {
        this.notifyListeners(GameEvent.ENDROUND);
        this.score = 50;
        this.percentErrosion = 0;
    }

    private void endParty()
    {
        notifyListeners(GameEvent.GAMEOVER);
    }

    public void startNewGame()
    {
        playerOne.resetLife();
        playerTwo.resetLife();
        notifyListeners(GameEvent.STARTGAME);
    }

    /********Listeners********/
    public void addListener(ListenerGameEvent listener)
    {
        this.listeners.Add(listener);
    }

    public void removeListener(ListenerGameEvent listener)
    {
        this.listeners.Remove(listener);
    }

    void notifyListeners(GameEvent eventToFire)
    {
        foreach(ListenerGameEvent listener in listeners)
        {
            listener.notifygameEvent(eventToFire);
        }
    }
}
