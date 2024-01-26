using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
      
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
