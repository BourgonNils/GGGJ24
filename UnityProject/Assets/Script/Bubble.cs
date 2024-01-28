using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] CorrespondanceCouleur correspondanceCouleur;
    [SerializeField] CorrespondanceSprite correspondanceSprite;
    [SerializeField] SpriteRenderer symboleSpriteRendered;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] float shrinkSpeed = 2f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private float scaleDuration = 0.3f;


    private float timeBeforeDisapearing;
    private SpriteRenderer spriteRenderer;
    private float shrinktime;
    [SerializeField] ParticleSystem particleOnPopPrefab;

    private Symbole mySymbole;
    private ColorBubble myColor = ColorBubble.VIOLET;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Start()
    {
        InputManager.instance.addBubble(this);

        timeBeforeDisapearing = lifeTime;
        this.shrinktime = lifeTime*shrinkSpeed;
        
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
            InputManager.instance.removeBubble(this);
            this.GetComponent<SpriteRenderer>().color = this.correspondanceCouleur.getKey(player.myColorBubble);
            StopAllCoroutines();
            ParticleSystem gerbeDeoiles = Instantiate(particleOnPopPrefab);
            gerbeDeoiles.transform.position = this.transform.position;
            gerbeDeoiles.startColor = this.correspondanceCouleur.getKey(this.myColor);
            gerbeDeoiles.Play();
            StartCoroutine(ScaleAnimation());
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

    IEnumerator ScaleAnimation()
    {
        float timer = 0f;
        Vector3 originalScale = transform.localScale;

        while (timer < scaleDuration)
        {
            float scale = Mathf.Lerp(1f, maxScale, timer / scaleDuration);
            transform.localScale = originalScale * scale;
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;

        while (timer < (scaleDuration) * 0.75f)
        {
            float scale = Mathf.Lerp(1f, 0f, timer / (scaleDuration*0.75f));
            transform.localScale = originalScale * scale;
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        this.pop();
    }
}
