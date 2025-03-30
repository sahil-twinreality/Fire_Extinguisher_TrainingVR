using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Pass_FireExtinguisher : MonoBehaviour
{
    public ParticleSystem fire;
    //public ParticleSystem smoke;
    public float reductionTime;
    public UnityEvent onAnimCompleted;
    //public UnityEvent onAnimCompletedDelay;
    public bool animCompleted;

    public void Extinguish()
    {
        StartCoroutine(ExtinguishFire());
    }

    /*public void ResetSmokeLifeTime()
    {
        var mainModule = smoke.main;
        mainModule.startLifetime = 15f;
        smoke.Play();
    }*/

    System.Collections.IEnumerator ExtinguishFire()
    {
        yield return new WaitForSeconds(1);
        ParticleSystem.MainModule main = fire.main;
        float particleLifetime = main.startLifetime.constant;
        DOTween.To(() => main.startLifetime.constant, x => main.startLifetime = x, 0.00001f, reductionTime);
        //yield return new WaitForSeconds(reductionTime);
        //smoke.startLifetime = 0;
        yield return new WaitForSeconds(reductionTime + 2.5f);
        animCompleted = true;
        onAnimCompleted.Invoke();
        //yield return new WaitForSeconds(1.5f);
        //onAnimCompletedDelay.Invoke();
    }
}