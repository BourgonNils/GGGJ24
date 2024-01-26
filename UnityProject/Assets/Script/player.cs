using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int life = 6;

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
    }
    
    void OnBas()
    {
        Debug.Log(gameObject.name + " bas");
    }

    void OnGauche()
    {
        Debug.Log(gameObject.name + " gauche");
    }

    void OnDroite()
    {
        Debug.Log(gameObject.name + " droite");
    }
}
