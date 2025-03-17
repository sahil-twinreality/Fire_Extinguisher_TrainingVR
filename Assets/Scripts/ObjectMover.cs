using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject Object;
    public Vector3 newPos;
    public Vector3 newRot;

    public void ChangeTransform()
    {
        Object.transform.localPosition = newPos;
        Object.transform.localEulerAngles = newRot;
    }
}
