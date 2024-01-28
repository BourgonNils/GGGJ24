using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameOver : MonoBehaviour
{
    public static PanelGameOver instance;

    [SerializeField] Canvas myCanvas;

    [SerializeField] GameObject panelVictoire1;
    [SerializeField] GameObject panelVictoire2;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }


    public void setVisible()
    {
        gameObject.SetActive(true);

        if (GameManager.instance.playerOne.getLife() == 0){
            panelVictoire2.SetActive(true);
            BackgroundMusic.instance.playSamyWin();
        }
        else {
            panelVictoire1.SetActive(true);
            BackgroundMusic.instance.playBobbyWin();
        }
        BackgroundMusic.instance.startMenuMusic();
        RandomTalk.instance.stopTalking();
    }

    public void onStartGame()
    {
        panelVictoire2.SetActive(false);
        panelVictoire1.SetActive(false);
        gameObject.SetActive(false);

    }

    public void onClickBtnRestart()
    {
        GameManager.instance.startNewGame(0f);
    }



    private void Start()
    {
        onStartGame();
    }
}
