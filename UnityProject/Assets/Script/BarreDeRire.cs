using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarreDeRire : MonoBehaviour
{

    Slider mySlider;

    private void Start()
    {
        mySlider = GetComponent<Slider>();
    }

    public void updateScore(int newScore)
    {
        mySlider.value = newScore;
    }


}
