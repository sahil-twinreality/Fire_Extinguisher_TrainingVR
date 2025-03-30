using UnityEngine;
using UnityEngine.Events;

public class FireExtCheck : MonoBehaviour
{
    public Pass_FireExtinguisher[] allFires;
    public UnityEvent onAllFireVanished;
    private bool invokeOnce;

    public void CheckFire()
    {
        if (invokeOnce)
            return;

        foreach (Pass_FireExtinguisher obj in allFires)
        {
            if (!obj.animCompleted)
            {
                Debug.Log("Still More to go :(");
                return;
            }

            Debug.Log("Hooray All Fire Vanished!!!");
            invokeOnce = true;
            Invoke("lateInvoke", 5.0f);
        }
    }

    public void lateInvoke()
    {
        onAllFireVanished.Invoke();
    }
}
