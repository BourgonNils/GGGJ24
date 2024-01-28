using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : Bubble
{

    
   
    [SerializeField] Sprite deadBallonRed;
    [SerializeField] Sprite deadBallonBlue;
    [SerializeField] float speed = 10f;


    // Start is called before the first frame update

    // Update is called once per frame
    public  void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        this.pop();
    }

    
    protected override void Start()
    {
        /*Do Nothing*/
    } 
   
}   
