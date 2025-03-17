using UnityEngine;
using DG.Tweening;

public class HandleAnim : MonoBehaviour
{
    public GameObject Handle;
    public Vector3 endPosition;
    public Vector3 endRotation;

    public void Animate()
    {
        Handle.transform.DOLocalMove(endPosition, 1.0f);
        Handle.transform.DOLocalRotate(endRotation, 1.0f);
    }
}
