using UnityEngine;
using UnityEngine.Events;

public class FireExtCheck : MonoBehaviour
{
    public FireExtinguisher[] allFires;
    public UnityEvent onAllFireVanished;
    private bool invokeOnce;

    public void CheckFire()
    {
        if (invokeOnce)
            return;

        foreach (FireExtinguisher obj in allFires)
        {
            if (!obj.animCompleted)
            {
                Debug.Log("Still More to go :(");
                return;
            }

            Debug.Log("Hooray All Fire Vanished!!!");
            invokeOnce = true;
            onAllFireVanished.Invoke();
        }

        /*foreach (FireExtinguisher obj in allFires)
        {
            if(obj.animCompleted == true)
            {
                if(!invokeOnce)
                {
                    Debug.Log("Hooray All Fire Vanished!!!");
                    onAllFireVanished.Invoke();
                    invokeOnce = true;
                }
            }
            else if(obj.animCompleted == false)
            {
                Debug.Log("Still More to go :(");
            }
        }*/
    }
}
