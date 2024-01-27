using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[CreateAssetMenu(fileName = "CorrespondanceSprite", menuName = "ScriptableObjects/Correspondance sprite")]
public class CorrespondanceSprite : ScriptableObject
{
    public List<symboleSprite> correspondances = new List<symboleSprite>();

    public Sprite getKey(Symbole key)
    {
        return correspondances.Where(correspondance => correspondance.key == key).First().valeur;
    }

    public int count()
    {
        return this.correspondances.Count();
    }

    public Symbole symboleAtIndex(int index)
    {
        return this.correspondances.ElementAt(index).key;
    }
}


[System.Serializable]
public class symboleSprite
{
    public Symbole key;
    public Sprite valeur;
}