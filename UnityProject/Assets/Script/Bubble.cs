using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] CorrespondanceCouleur correspondanceCouleur;
    [SerializeField] CorrespondanceSprite correspondanceSprite;
    [SerializeField] float lifeTime = 3f;
    float timeBeforeDisapearing;
    [SerializeField] SpriteRenderer symboleSpriteRendered;


  

    Symbole mySymbole;
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

    public void createBubble(Symbole symbole,ColorBubble color)
    {
        this.myColor = color;
        mySymbole = symbole;
        this.GetComponent<SpriteRenderer>().color = this.correspondanceCouleur.getKey(color);
        this.symboleSpriteRendered.sprite = this.correspondanceSprite.getKey(symbole);
    }

    /*Retourne true si la bulle doit exploser*/
    public bool receiveInput(Player player, Direction dir)
    {
        if (this.shouldExplode(player,dir))
        {   
            this.pop();
            return true;
        }
        return false;
    }

    bool shouldExplode(Player player, Direction dir)
    {
        bool bonSymbole = InputManager.instance.correspondanceDirection[dir] == this.mySymbole;
        
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
