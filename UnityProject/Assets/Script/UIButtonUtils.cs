using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonUtils : MonoBehaviour
{
    public void startNewGame()
    {
        GameManager.instance.startNewGame();
    }
}
