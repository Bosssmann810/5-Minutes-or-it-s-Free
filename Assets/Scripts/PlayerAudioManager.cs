using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip boostAudioClip;
    public bool playingAudio;


    public void PlayAudio()
    {
        if (playingAudio == false)
        {
            playingAudio = true;
            audioSource.clip = boostAudioClip;
            audioSource.Play();
        }
    }
    public void StopAudio()
    {
        playingAudio = false;
        audioSource.Stop();
    }

}
