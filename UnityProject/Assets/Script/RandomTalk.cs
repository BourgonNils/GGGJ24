using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTalk : MonoBehaviour
{

    [SerializeField] private List<AudioClip> bobbyTalk;
    [SerializeField] private List<AudioClip> samyTalk;
    [SerializeField] private AudioSource bobbySound;
    [SerializeField] private AudioSource samySound;
    private bool isEventSoundPlaying = false;
    private bool start = false;

    public static RandomTalk instance;

    void Awake(){
        if(RandomTalk.instance == null){
            RandomTalk.instance = this;
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!this.isPlayerTalking() && !this.isEventSoundPlaying && start){
            int randPlay = UnityEngine.Random.Range(0, 1000);
            if(randPlay == 0){
                this.playRandomTalk();
            }
        }
    }

    private bool isPlayerTalking(){
        return this.bobbySound.isPlaying || this.samySound.isPlaying;
    }

    private void playBobbyTalk(){
        int randIndex = UnityEngine.Random.Range(0, this.bobbyTalk.Count - 1);
        bobbySound.clip = this.bobbyTalk[randIndex];
        bobbySound.Play();
    }

    private void playSamyTalk(){
        int randIndex = UnityEngine.Random.Range(0, this.samyTalk.Count - 1);
        samySound.clip = this.samyTalk[randIndex];
        samySound.Play();
    }

    private void playRandomTalk(){
        int randPlay = UnityEngine.Random.Range(0, 2);
        if(randPlay == 0){
            this.playBobbyTalk();
        } else {
            this.playSamyTalk();
        }
    }

    // Méthode pour appeler lorsque l'événement sonore commence
    public void StartEventSound()
    {
        Debug.Log("event sonore en cours");
        this.samySound.Stop();
        this.bobbySound.Stop();
        isEventSoundPlaying = true;
    }

    // Méthode pour appeler lorsque l'événement sonore se termine
    public void EndEventSound()
    {
        Debug.Log("Fin d'event sonore");
        isEventSoundPlaying = false;
    }

    public void startTalking(){
        this.start = true;
    }

    public void stopTalking(){
        this.start = false;
    }


}
