using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class SillhoutteBlinker : MonoBehaviour
{
    public Renderer[] ObjectToHighlight;

    public Material DefaultMat;

    public float blinkInterval = 0.5f;

    private bool isBlinking = false;
    private Coroutine blinkCoroutine;

    public void StartBlink()
    {
        if (!isBlinking)
        {
            blinkCoroutine = StartCoroutine(Blink());
        }
    }

    public void StopBlinkEffect()
    {
        if (isBlinking)
        {
            StopCoroutine(blinkCoroutine);
            isBlinking = false;

            foreach (var obj in ObjectToHighlight)
            {
                obj.material = DefaultMat;
            }
        }
    }

    private IEnumerator Blink()
    {

        isBlinking = true;
        Color originalColor = DefaultMat.color;

        while (isBlinking)
        {
            foreach (var obj in ObjectToHighlight)
            {
                //obj.material.DOColor(targetcolor, blinkInterval);
                obj.material.DOFade(0.5f, blinkInterval);
            }

            yield return new WaitForSeconds(blinkInterval);

            foreach (var obj in ObjectToHighlight)
            {
                //obj.material.DOColor(Color.white, blinkInterval);
                obj.material.DOFade(0.25f, blinkInterval);
            }

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
