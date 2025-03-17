using UnityEngine;
using DG.Tweening;

public class ResetPosition : MonoBehaviour
{
    private Vector3 initialPos;
    private Quaternion initialRot;
    private void Start()
    {
        initialPos = gameObject.transform.position;
        initialRot = gameObject.transform.rotation;
    }

    System.Collections.IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.DOMove(initialPos, 0.3f);
        gameObject.transform.DORotate(initialRot.eulerAngles, 0.3f);
    }
    public void Reset()
    {
        StartCoroutine(ResetPos());
    }
}
