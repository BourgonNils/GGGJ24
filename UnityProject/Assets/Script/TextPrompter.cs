using System.Collections;
using UnityEngine;
using TMPro;


public class TextPrompter : MonoBehaviour
{
    public static TextPrompter instance;


    TextMeshProUGUI mytext;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        mytext = GetComponent<TextMeshProUGUI>();
    }

    public void printText(string message, float duration=2f)
    {
        mytext.gameObject.SetActive(true);
        mytext.text = message;
        StartCoroutine(eraseAfterTime(duration));
    }

    IEnumerator eraseAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        mytext.text = "";

        mytext.gameObject.SetActive(false);
    }


}
