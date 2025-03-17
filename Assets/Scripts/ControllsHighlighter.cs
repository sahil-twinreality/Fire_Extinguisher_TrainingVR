using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ControllsHighlighter : MonoBehaviour
{
    public GameObject[] Hands;
    public GameObject[] Controllers;
    public Renderer[] ObjectToHighlight;
    public Renderer[] OtherParts;

    public Material DefaultMat;
    //public Material targetMat;
    public Material transparentMat;

    public Color targetcolor;

    public float blinkInterval = 0.5f;

    private bool isBlinking = false;
    private Coroutine blinkCoroutine;

    public void HighlightObject()
    {
        foreach (var obj in Hands)
        {
            obj.gameObject.SetActive(false);
        }

        foreach (var obj in Controllers)
        {
            obj.gameObject.SetActive(true);
        }

        foreach (var part in OtherParts)
        {
            part.material = transparentMat;
        }

        if (!isBlinking)
        {
            blinkCoroutine = StartCoroutine(Blink());
        }
    }

    public void RemoveHighlight()
    {
        foreach (var part in OtherParts)
        {
            part.material = DefaultMat;
        }

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

    public void StopBlinkEffect()
    {
        foreach (var part in OtherParts)
        {
            part.material = DefaultMat;
        }

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

    public void SwitchControllersToHands()
    {
        foreach (var obj in Hands)
        {
            obj.gameObject.SetActive(true);
        }

        foreach (var obj in Controllers)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private IEnumerator Blink()
    {
        /*isBlinking = true;
        while (isBlinking)
        {
            foreach (var obj in ObjectToHighlight)
            {
                obj.material = targetMat;
            }

            yield return new WaitForSeconds(blinkInterval);

            foreach (var obj in ObjectToHighlight)
            {
                obj.material = DefaultMat;
            }

            yield return new WaitForSeconds(blinkInterval);
        }*/

        isBlinking = true;
        Color originalColor = DefaultMat.color;
        //Color targetColor = Color.blue;

        while (isBlinking)
        {
            foreach (var obj in ObjectToHighlight)
            {
                //obj.material.color = targetColor;
                obj.material.DOColor(targetcolor, blinkInterval);
            }

            yield return new WaitForSeconds(blinkInterval);

            foreach (var obj in ObjectToHighlight)
            {
                //obj.material.color = Color.white;
                obj.material.DOColor(Color.white, blinkInterval);
            }

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}