using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FireExtinguisher : MonoBehaviour
{
    public ParticleSystem fire;
    public float reductionTime;
    public UnityEvent onAnimCompleted;
    public bool animCompleted;

    public void Extinguish()
    {
        StartCoroutine(ExtinguishFire());
    }

    System.Collections.IEnumerator ExtinguishFire()
    {
        yield return new WaitForSeconds(1);
        ParticleSystem.MainModule main = fire.main;
        float particleLifetime = main.startLifetime.constant;
        DOTween.To(() => main.startLifetime.constant, x => main.startLifetime = x, 0.00001f, reductionTime);
        yield return new WaitForSeconds(reductionTime);
        animCompleted = true;
        onAnimCompleted.Invoke();
    }
}