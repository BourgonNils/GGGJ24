using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BaffeGenerator : MonoBehaviour
{
    public static BaffeGenerator instance;

    Animator myAnimator;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        if (myAnimator == null)
            throw new System.Exception("necessite un animator");
    }

    public void baffe(int playerId, float delay=0f)
    {
        if(delay != 0)
        {
            StartCoroutine(baffeDelayed(playerId,delay));
            return;
        }
        myAnimator.SetTrigger("baffe" + playerId);
    }
    
    IEnumerator baffeDelayed(int playerId,float delay)
    {
        yield return new WaitForSeconds(delay);
        baffe(playerId);
    }


}
