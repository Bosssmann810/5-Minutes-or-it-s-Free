using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource BoostAudioSource;
    public AudioClip boostAudioClip;
    public bool playingBoostAudio;
    public bool playingJumpAudio;
    public AudioClip jumpAudioClip;
    public AudioSource jumpAudioSource;


    public void PlayBoostAudio()
    {
        if (playingBoostAudio == false)
        {
            playingBoostAudio = true;
            BoostAudioSource.clip = boostAudioClip;
            BoostAudioSource.Play();
        }
    }
    public void StopBoostAudio()
    {
        playingBoostAudio = false;
        BoostAudioSource.Stop();
    }

    public void PlayJumpAudio()
    {
        jumpAudioSource.clip = jumpAudioClip;
        jumpAudioSource.Play();
    }


}
