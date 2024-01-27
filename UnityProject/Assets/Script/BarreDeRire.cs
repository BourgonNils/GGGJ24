using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarreDeRire : MonoBehaviour
{

    [SerializeField] Slider mainSlider;
    [SerializeField] Slider errosionGauche;
    [SerializeField] Slider errosionDroite;

    private void Start()
    {
        mainSlider = GetComponent<Slider>();
    }

    public void updateScore(int newScore)
    {
        mainSlider.value = newScore;
    }

    public void updateErrosion(float newErrosion)
    {
        errosionDroite.value = newErrosion;
        errosionGauche.value = newErrosion;
    }

}
