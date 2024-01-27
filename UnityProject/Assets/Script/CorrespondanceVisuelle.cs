using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrespondanceVisuelle : MonoBehaviour
{
    [SerializeField] CorrespondanceSprite correspondance;
    [SerializeField] SpriteRenderer symboleHaut;
    [SerializeField] SpriteRenderer symboleBas;
    [SerializeField] SpriteRenderer symboleGauche;
    [SerializeField] SpriteRenderer symboleDroite;




    private void Start()
    {
        this.symboleHaut.sprite =  getCorresponding(Direction.HAUT);
        this.symboleBas.sprite = getCorresponding(Direction.BAS);
        this.symboleGauche.sprite = getCorresponding(Direction.GAUCHE);
        this.symboleDroite.sprite = getCorresponding(Direction.DROITE);
    }

    Sprite getCorresponding(Direction dir)
    {
        return this.correspondance.getKey(InputManager.instance.correspondanceDirection[dir]);
    }

}
