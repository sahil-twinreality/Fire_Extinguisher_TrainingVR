using UnityEngine;
using UnityEngine.Events;

public class ParticleCollision : MonoBehaviour
{
    public UnityEvent onCollisionDetected;
    private bool invokeOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Foam"))
        {
            if (!invokeOnce)
            {
                onCollisionDetected.Invoke();
                invokeOnce = true;
                Debug.Log("Particle Hitting!!!");
            }
        }
        //Debug.Log("Particle Hitting!!!");
    }
    /*private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("Foam"))
        {
            if(!invokeOnce)
            {
                onCollisionDetected.Invoke();
                Debug.Log("Particle Hitting!!!");
                invokeOnce = true;
            }
        }
    }*/
}
