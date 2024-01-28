using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    public Dictionary<Direction, Symbole> correspondanceDirection = new Dictionary<Direction, Symbole>();

    public int costMissInput = 3;

    bool isListeningToInput = false;
    [SerializeField] private List<AudioClip> pops_TODELETE;


    public delegate void InputPlayer(Player player, Direction dir);
    public static event InputPlayer onInputPlayer;



    private void Awake()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        this.randomizeSymbole();
    }

    /*Appel? par le joueur*/
    public void onInput(Player player, Direction dir)
    {
        if (!isListeningToInput)
            return;

        onInputPlayer?.Invoke(player, dir);
        GameManager.instance.looseScore(player, costMissInput);
    }


    public void setListeningToInput(bool shouldListen)
    {
        isListeningToInput = shouldListen;
    }

    public void randomizeSymbole() {

        List<Symbole> symboles = ((Symbole[])Enum.GetValues(typeof(Symbole))).ToList();
        List<Direction> directions = ((Direction[]) Enum.GetValues(typeof(Direction))).ToList();


        this.correspondanceDirection.Clear();

        foreach(var direction in directions)
        {
            Symbole addedSymbole = this.getRandomSymbole(symboles);
            symboles.Remove(addedSymbole);
            correspondanceDirection.Add(direction,addedSymbole);
        }

    }

    public void onEndRound()
    {
        GameObject[] symboles = GameObject.FindGameObjectsWithTag("symbole");
        foreach(var symbole in symboles)
        {
            Destroy(symbole);
        }
        isListeningToInput = false;
    }

    private Symbole getRandomSymbole(List<Symbole> symboles)
    {
        System.Random rand = new System.Random();
        int randomIndex = rand.Next(symboles.Count);

        return  symboles.ElementAt(randomIndex);
    }
}
