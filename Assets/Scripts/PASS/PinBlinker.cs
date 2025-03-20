using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PinBlinker : MonoBehaviour
{
    public Renderer[] ObjectToHighlight;

    public Material DefaultMat;
    //public Material transparentMat;

    public Color targetcolor;

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
                obj.material.DOColor(targetcolor, blinkInterval);
            }

            yield return new WaitForSeconds(blinkInterval);

            foreach (var obj in ObjectToHighlight)
            {
                obj.material.DOColor(Color.white, blinkInterval);
            }

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
