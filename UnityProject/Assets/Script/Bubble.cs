using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    float timeBeforeDisapearing;

    Direction myDirection = Direction.HAUT;

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

    public void setDirection(Direction newDir)
    {
        myDirection = newDir;
    }

    /*Retourne true si la bulle doit exploser*/
    public bool receiveInput(Player player, Direction dir)
    {
        if (this.shouldExplode())
        {   
            this.pop();
            return true;
        }
        return false;
    }

    bool shouldExplode()
    {
        return true;
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
