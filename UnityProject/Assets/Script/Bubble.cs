using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    float timeBeforeDisapearing;

    Symbole mySymbole ;

    ColorBubble myColor = ColorBubble.VIOLET;

    private void Start()
    {
        timeBeforeDisapearing = lifeTime;
    }

   

    // Update is called once per frame
    void Update()
    {
        timeBeforeDisapearing -= Time.deltaTime;
        if (timeBeforeDisapearing <= 0 )
        {
            pop();
        }
    }

    public void setSymbole(Symbole symbole)
    {
        mySymbole = symbole;
    }

    /*Retourne true si la bulle doit exploser*/
    public bool receiveInput(int numeroJoueur, Direction dir)
    {
        if (this.shouldExplode( numeroJoueur,  dir))
        {   
            this.pop();
            return true;
        }
        return false;
    }

    bool shouldExplode(int numeroJoueur, Direction dir)
    {
        bool bonSymbole = GameManager.instance.correspondance[dir] == this.mySymbole;
        bool bonneCouleur = true;

        return bonSymbole && bonneCouleur;
    }

    void pop()
    {
        Destroy(this.gameObject);
    }

    
    private void Awake()
    {
        InputManager.instance.addBubble(this);
    }

    private void OnDestroy()
    {
        InputManager.instance.removeBubble(this);
    }
}
