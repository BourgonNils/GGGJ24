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
    [SerializeField] CorrespondanceVisuelle zoneCorrespondance;


    float percentErrosion = 0;
    float maxErrosion = 40;
    float valueErroded = 0;

    List<ListenerGameEvent> listeners = new List<ListenerGameEvent>();

    public enum GameEvent { GAMEOVER, STARTGAME, ENDROUND, STARTROUND,};

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
        if(zoneCorrespondance == null )
            throw new System.Exception("Pas de zone correspondance ?");

    }

    public int getScore()
    {
        return this.score;
    }

    // Update is called once per frame
    void Update()
    {
        this.addErrosion(0.01f * Time.deltaTime);
    }

    void addErrosion(float newErrosion)
    {
        
        if (newErrosion >1 || newErrosion < 0 )
            throw new System.Exception("Doit ?tre compris entre 0 et 1");

        this.percentErrosion += newErrosion;

        if (percentErrosion > 1)
            percentErrosion = 1;

        valueErroded = maxErrosion * this.percentErrosion;
        checkIfDead();
        mySlider.updateErrosion(valueErroded);
    }

    void onUpdateScore()
    {
        checkIfDead();
        mySlider.updateScore(this.score);
    }

    public void checkIfDead()
    {
        bool endGame = false;
        if (this.score <= (0 + valueErroded))
        {
            endGame = this.playerOne.Laught();
            resetRound();
        }
        else if (this.score >= 100 - valueErroded)
        {
            endGame = this.playerTwo.Laught();
            resetRound();
        }
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
        mySlider.updateScore(this.score);
        StartCoroutine(waitThenLaunchNewRound());
    }

    public IEnumerator waitThenLaunchNewRound()
    {
        yield return new WaitForSeconds(2.5f);

        TextPrompter.instance.printText("GO !");
        notifyListeners(GameEvent.STARTROUND,1f);
    }

    private void endParty()
    {
        notifyListeners(GameEvent.GAMEOVER);
    }

    public void startNewGame()
    {
        playerOne.resetLife();
        playerTwo.resetLife();
        zoneCorrespondance.onStart();
        
        notifyListeners(GameEvent.STARTGAME,4f);
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

    public void notifyListeners(GameEvent eventToFire, float delay = 0f)
    {
        if (delay != 0)
        {
            StartCoroutine(waitThenFireEvent(eventToFire, delay));
            return;
        }

        foreach(ListenerGameEvent listener in listeners)
        {
            listener.notifygameEvent(eventToFire);
        }
    }

    IEnumerator waitThenFireEvent(GameEvent eventToFire, float delay)
    {
        yield return new WaitForSeconds(delay);
        notifyListeners(eventToFire);
    }


    public void startGame()
    {
        Debug.Log("strat");
    }
}
