using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int life = 6;
    public int playerId = 0;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public bool Laught()
    {
        this.life--;
        return this.life == 0;
    }


    void OnHaut()
    {
        
        Debug.Log(gameObject.name + " haut");
        InputManager.instance.onInput(this, Direction.HAUT);
    }
    
    void OnBas()
    {
        Debug.Log(gameObject.name + " bas");
        InputManager.instance.onInput(this, Direction.BAS);
    }

    void OnGauche()
    {
        Debug.Log(gameObject.name + " gauche");
        InputManager.instance.onInput(this, Direction.GAUCHE);
    }

    void OnDroite()
    {
        Debug.Log(gameObject.name + " droite");
        InputManager.instance.onInput(this, Direction.DROITE);
    }
}
