using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class GoPrinter : MonoBehaviour
{

    public static GoPrinter instance;
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
    }

    public void printGOOOOO()
    {
        myAnimator.SetTrigger("GO");
    } 
   
}
