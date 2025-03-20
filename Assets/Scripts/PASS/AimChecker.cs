using UnityEngine;
using UnityEngine.Events;

public class AimChecker : MonoBehaviour
{
    public float timer;
    public UnityEvent onCollisionDetected;
    private bool invokeOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireCube"))
        {
            if (!invokeOnce)
            {
                StartCoroutine(invokeFun());
                invokeOnce = true;
                Debug.Log("Particle Hitting!!!");
            }
        }
    }

    System.Collections.IEnumerator invokeFun()
    {
        yield return new WaitForSeconds(timer);
        onCollisionDetected.Invoke();
    }
}
