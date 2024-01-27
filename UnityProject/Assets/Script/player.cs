using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    [SerializeField] [Range(1,6)] private int maxLife = 3;
    private int life ;
    [Range(0, 1)] public int playerId = 0;
    public ColorBubble myColorBubble;

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
       if(myColorBubble != ColorBubble.ROUGE && myColorBubble != ColorBubble.BLEU)
            throw new System.Exception("Couleur de joueur non valide");
        
        if(myAnimator ==null)
            throw new System.Exception("Le joueur a besoin d'un animator");


        resetLife();
    }

    public void resetLife()
    {
        life = maxLife;
        myAnimator.SetInteger("HP", life);
    }

    public ColorBubble GetColorBubble() 
    { 
        return myColorBubble; 
    }
    public bool Laught()
    {
        this.life--;
        Debug.Log("Player " + playerId + " laught, life remaining " + this.life);
        myAnimator.SetInteger("HP", life);

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
