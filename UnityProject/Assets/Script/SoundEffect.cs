using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    [SerializeField] private List<AudioClip> woosh;
    [SerializeField] private List<AudioClip> clap;
    [SerializeField] private AudioSource soundClap;
    [SerializeField] private AudioSource soundWoosh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playWoosh()
    {
        int randIndedxWoosh = UnityEngine.Random.Range(0, this.woosh.Count - 1);
        soundWoosh.clip = this.woosh[randIndedxWoosh];
        soundWoosh.Play();
    }

    public void playClap()
    {
        int randIndedxClap = UnityEngine.Random.Range(0, this.clap.Count - 1);
        soundClap.clip = this.clap[randIndedxClap];
        soundClap.Play();
    }
}
