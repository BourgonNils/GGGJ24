using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceuil : MonoBehaviour
{

    [SerializeField] Animator leftRido;
    [SerializeField] Animator rightRido;
    [SerializeField] Animator tutoAnimator;
    [SerializeField] GameObject buttonPlay;
    [SerializeField] GameObject buttonTuto;
    [SerializeField] GameObject buttonRetour;
    [SerializeField] GameObject pancarte;
    [SerializeField] float speed;

    Animator pancartAnimator;


    // Start is called before the first frame update
    void Start()
    {
        this.pancartAnimator = this.pancarte.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(startGameAnimation());
    }

    public void tutoIn ()
    {
        this.tutoAnimator.SetTrigger("in");
        this.pancartAnimator.SetTrigger("out");
        this.buttonPlay.SetActive(false);
        this.buttonRetour.SetActive(true);
        this.buttonTuto.SetActive(false);
    }

    public void tutoOut()
    {
        this.tutoAnimator.SetTrigger("out");
        this.pancartAnimator.SetTrigger("in");
        this.buttonPlay.SetActive(true);
        this.buttonRetour.SetActive(false);
        this.buttonTuto.SetActive(true);
    }

    IEnumerator startGameAnimation()
    {

        this.leftRido.SetTrigger("Open");
        this.rightRido.SetTrigger("Open");
        this.pancartAnimator.SetTrigger("out");
        this.buttonTuto.SetActive(false);


        float elapsedTime = 0f;
        Vector2 originalSize = buttonPlay.GetComponent<RectTransform>().sizeDelta;
        while (elapsedTime < 1f)
        {
            buttonPlay.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(originalSize, Vector2.zero, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);


        GameManager.instance.startNewGame(4f);
        Destroy(this.gameObject);

    }



    public void MoveElementUp(RectTransform elementToMove)
    {
        // Déplacer l'élément vers le haut
        Vector3 targetPosition = elementToMove.anchoredPosition + Vector2.up * 100f; // Déplacement de 100 pixels vers le haut
        StartCoroutine(MoveCoroutine(targetPosition,elementToMove));
    }

    IEnumerator MoveCoroutine(Vector3 targetPosition, RectTransform elementToMove)
    {
        while (Vector3.Distance(elementToMove.anchoredPosition, targetPosition) > 0.1f)
        {
            // Interpolation linéaire pour un mouvement fluide
            elementToMove.anchoredPosition = Vector3.Lerp(elementToMove.anchoredPosition, targetPosition, Time.deltaTime * speed);
            yield return null;
        }

        // Assurez-vous que l'élément soit bien positionné à la position cible
        elementToMove.anchoredPosition = targetPosition;
    }
}
