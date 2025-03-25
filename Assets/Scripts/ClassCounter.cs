using UnityEngine;
using UnityEngine.Events;

public class ClassCounter : MonoBehaviour
{
    public int counter;
    public UnityEvent onAllClassCompleted;
    public void IncreaseCounter()
    {
        counter++;

        if (counter == 5)
        {
            Debug.Log("Event Completed");
            Invoke("InvokeUnityEvent", 0.1f);
        }
    }

    public void InvokeUnityEvent()
    {
        onAllClassCompleted.Invoke();
    }
}
