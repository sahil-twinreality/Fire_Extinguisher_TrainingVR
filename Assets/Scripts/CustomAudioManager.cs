using UnityEngine;

public class CustomAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] AudioClips;

    public void PlayCustomAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void PlayAudio(int audioNumber)
    {
        AudioClip clip = AudioClips[audioNumber];
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log("Playing Audio");
    }
}
