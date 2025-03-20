using UnityEngine;
using DG.Tweening;

public class HandleAnim : MonoBehaviour
{
    public GameObject Handle;
    public Vector3 endPosition;
    public Vector3 endRotation;

    public Vector3 initialPosition;
    public Vector3 initialRotation;

    public void Animate()
    {
        initialPosition = Handle.transform.localPosition;
        initialRotation = Handle.transform.localRotation.eulerAngles;
        Handle.transform.DOLocalMove(endPosition, 1.0f);
        Handle.transform.DOLocalRotate(endRotation, 1.0f);
    }

    public void Reset()
    {
        Handle.transform.DOLocalMove(initialPosition, 1.0f);
        Handle.transform.DOLocalRotate(initialRotation, 1.0f);
    }
}
