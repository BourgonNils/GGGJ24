using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    float timeBeforeDisapearing;


    public SpriteRenderer symboleSpriteRendered;

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
        this.GetComponent<SpriteRenderer>().color = GameManager.instance.correspondanceColor[color];
        this.symboleSpriteRendered.sprite = GameManager.instance.correspondanceSprite[symbole];
        this.symboleSpriteRendered.color = Color.black;
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
        bool bonSymbole = GameManager.instance.correspondanceSymbole[dir] == this.mySymbole;
        
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
