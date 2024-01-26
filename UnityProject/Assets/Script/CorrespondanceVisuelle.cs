using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrespondanceVisuelle : MonoBehaviour
{
    [SerializeField] SpriteRenderer symboleHaut;
    [SerializeField] SpriteRenderer symboleBas;
    [SerializeField] SpriteRenderer symboleGauche;

    [SerializeField] SpriteRenderer symboleDroite;


    private void Start()
    {
        symboleHaut.sprite =  getCorresponding(Direction.HAUT);
        symboleBas.sprite = getCorresponding(Direction.BAS);
        symboleGauche.sprite = getCorresponding(Direction.GAUCHE);
        symboleDroite.sprite = getCorresponding(Direction.DROITE);
    }

    Sprite getCorresponding(Direction dir)
    {
        Symbole symbole = GameManager.instance.correspondanceSymbole[dir];
        return GameManager.instance.correspondanceSprite[symbole];
    }

}
