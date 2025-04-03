using UnityEngine;
using UnityEngine.Events;

public class OnTimeAction : MonoBehaviour
{
    public UnityEvent OneTimeActions;
    private bool invokedOnce;

    public void InvokeActions()
    {
        if(!invokedOnce)
        {
            OneTimeActions.Invoke();
            invokedOnce = true;
        }
    }
}
