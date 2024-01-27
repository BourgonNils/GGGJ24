using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{

    
    [SerializeField] CorrespondanceCouleur correspondanceCouleur;
    [SerializeField] CorrespondanceSprite correspondanceSprite;
    [SerializeField] SpriteRenderer symboleSpriteRendered;
    [SerializeField] Sprite deadBallonRed;
    [SerializeField] Sprite deadBallonBlue;
    [SerializeField] float speed = 10f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private float scaleDuration = 0.3f;


    private Symbole mySymbole;
    private ColorBubble myColor = ColorBubble.VIOLET;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        this.pop();
    }


    public void createBallon(Symbole symbole, ColorBubble color)
    {
        this.myColor = color;
        mySymbole = symbole;
        this.GetComponent<SpriteRenderer>().color = this.correspondanceCouleur.getKey(color);
        this.symboleSpriteRendered.sprite = this.correspondanceSprite.getKey(symbole);
    }

    /*Retourne true si la bulle doit exploser*/
    public bool receiveInput(Player player, Direction dir)
    {
        if (this.shouldExplode(player, dir))
        {
            InputManager.instance.removeBallon(this);
            this.GetComponent<SpriteRenderer>().sprite = player.myColorBubble == ColorBubble.ROUGE ? deadBallonRed : deadBallonBlue;
            StartCoroutine(ScaleAnimation());
            return true;
        }
        return false;
    }

    bool shouldExplode(Player player, Direction dir)
    {
        bool bonSymbole = InputManager.instance.correspondanceDirection[dir] == this.mySymbole;

        bool bonneCouleur = myColor == player.GetColorBubble();
           
        return bonSymbole && bonneCouleur;
    }

    private void Awake()
    {
        InputManager.instance.addBallon(this);
    }

    protected void pop()
    {
        Destroy(gameObject);
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
            float scale = Mathf.Lerp(1f, 0f, timer / (scaleDuration * 0.75f));
            transform.localScale = originalScale * scale;
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        this.pop();
    }
}   
