using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] CorrespondanceCouleur correspondanceCouleur;
    [SerializeField] CorrespondanceSprite correspondanceSprite;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] SpriteRenderer symboleSpriteRendered;


    private float timeBeforeDisapearing;
    private SpriteRenderer spriteRenderer;
    private float shrinktime;





    Symbole mySymbole;
    ColorBubble myColor = ColorBubble.VIOLET;

    private void Start()
    {
        timeBeforeDisapearing = lifeTime;
        this.shrinktime = 2f * lifeTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShrinkOverTime());
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

    IEnumerator ShrinkOverTime()
    {
        Vector3 originalScale = transform.localScale;
        Color originalColor = spriteRenderer.color;
        float timer = 0f;

        while (timer < shrinktime)
        {
            float scale = Mathf.Lerp(1f, 0f, timer / shrinktime); // Calculer la nouvelle taille en fonction du temps
            transform.localScale = originalScale * scale;


            float alpha = Mathf.Lerp(1f, 0f, timer / shrinktime); // Calculer le nouvel alpha en fonction du temps
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            spriteRenderer.color = newColor;



            timer += Time.deltaTime;
            yield return null; // Attendre jusqu'au prochain frame
        }


        // Assurez-vous que l'échelle est à zéro à la fin de la coroutine
        transform.localScale = Vector3.zero;
    }
}
