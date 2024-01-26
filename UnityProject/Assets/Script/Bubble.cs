using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    float timeBeforeDisapearing;
    int score = 5;
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
    public bool receiveInput(Player player, Direction dir)
    {
        if (this.shouldExplode(player,dir))
        {   
            this.pop();
            GameManager.instance.UpdateScore(player, this.score);
            return true;
        }
        return false;
    }

    bool shouldExplode(Player player, Direction dir)
    {
        bool bonSymbole = GameManager.instance.correspondance[dir] == this.mySymbole;
        
        bool bonneCouleur = myColor == ColorBubble.VIOLET 
            || myColor == player.GetColorBubble();

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
