using UnityEngine;
using DG.Tweening;

public class ResetNozzlePosition : MonoBehaviour
{
    private Vector3 initialPos;
    private Quaternion initialRot;

    public GameObject transfromReference;

    System.Collections.IEnumerator ResetPos()
    {
        
        //initialRot = transfromReference.transform.rotation;
        yield return new WaitForSeconds(0.01f);
        
        //gameObject.transform.DORotate(initialRot.eulerAngles, 0.3f);
    }
    public void Reset()
    {
        //StartCoroutine(ResetPos());
        initialPos = transfromReference.transform.position;
        //Debug.Log(initialPos);
        gameObject.transform.position = initialPos;
        //Debug.Log(gameObject.transform.position);
    }
}
