using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[CreateAssetMenu(fileName = "CorrespondanceCouleur", menuName = "ScriptableObjects/Correspondance couleurs")]
public class CorrespondanceCouleur : ScriptableObject
{
    public List<colorBubbleColor> correspondances = new List<colorBubbleColor>();

    public Color getKey(ColorBubble key)
    {
        return correspondances.Where(correspondance => correspondance.key == key).First().valeur;
    }
}

[System.Serializable]
public class colorBubbleColor
{
    public ColorBubble key;
    public Color valeur;
}