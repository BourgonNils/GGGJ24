using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource voice;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip start;
    [SerializeField] private AudioClip bobbyWin;
    [SerializeField] private AudioClip samyWin;

    public static BackgroundMusic instance;

    void Awake(){
        if(BackgroundMusic.instance == null){
            BackgroundMusic.instance = this;
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.backgroundMusic.clip = this.menuMusic;
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.backgroundMusic.isPlaying){
            this.backgroundMusic.Play();
        }
    }

    
    public void playStart(){
        this.voice.clip = this.start;
        this.voice.Play();
    }

    public void playBobbyWin(){
        this.voice.clip = this.bobbyWin;
        this.voice.Play();
    }

    public void playSamyWin(){
        this.voice.clip = this.samyWin;
        this.voice.Play();
    }

    public void startGameMusic(){
        this.StartFadeOut(1F, this.gameMusic);
    }

    private void StartFadeOut(float duration, AudioClip clip)
    {
        StartCoroutine(FadeOut(duration, clip));
    }

    IEnumerator FadeOut(float duration, AudioClip clip)
    {
        float startVolume = this.backgroundMusic.volume;

        while (this.backgroundMusic.volume > 0)
        {
            this.backgroundMusic.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        this.backgroundMusic.Stop();
        this.backgroundMusic.clip = clip;
        this.backgroundMusic.volume = startVolume; // Réinitialise le volume à sa valeur initiale

    }
}
