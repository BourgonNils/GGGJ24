using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceuil : MonoBehaviour
{

    [SerializeField] Animator leftRido;
    [SerializeField] Animator rightRido;
    [SerializeField] GameObject button;
    [SerializeField] GameObject pancarte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(startGameAnimation());
    }


    IEnumerator startGameAnimation()
    {

        this.leftRido.SetTrigger("Open");
        this.rightRido.SetTrigger("Open");
        this.pancarte.GetComponent<Animator>().SetTrigger("Open");


        float elapsedTime = 0f;
        Vector2 originalSize = button.GetComponent<RectTransform>().sizeDelta;
        while (elapsedTime < 1f)
        {
            button.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(originalSize, Vector2.zero, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);


        GameManager.instance.startNewGame(4f);
        Destroy(this.gameObject);

    }
}
