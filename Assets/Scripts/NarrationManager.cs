using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;

public class NarrationManager : MonoBehaviour
{
    public GameObject UI;
    public Vector3 position;
    public Vector3 rotation;

    public TMP_Text text;
    [TextArea(3, 10)]
    public string string1;
    [TextArea(3, 10)]
    public string string2;

    public float narration1WaitTime;

    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    public UnityEvent onNarrationStart;
    public UnityEvent onNarration1End;
    public UnityEvent onNarration2Start;

    public void PlayNarration1()
    {
        onNarrationStart.Invoke();
        text.text = string1;
        audioSource.clip = audioClip1;
        audioSource.Play();

        Invoke("OnAudioPlayed", audioClip1.length + 1);

        if (string2.Length > 2)
        {
            Invoke("PlayNarration2", audioClip1.length + narration1WaitTime);
        }
    }

    private void PlayNarration2()
    {
        onNarration2Start.Invoke();
        text.text = string2;
        audioSource.clip = audioClip2;
        audioSource.Play();
    }

    private void OnAudioPlayed()
    {
        onNarration1End.Invoke();
    }

    public void ChangeUITransform()
    {
        UI.transform.DOLocalMove(position, 0.3f);
        UI.transform.DORotate(rotation, 0.3f);
    }
}