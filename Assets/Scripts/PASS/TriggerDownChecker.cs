using UnityEngine;
using UnityEngine.Events;
using BNG;

public class TriggerDownChecker : GrabbableEvents
{
    public bool checkRightTriggerUp;
    public bool checkRightTigger;

    public UnityEvent onRightTriggerRevoked;
    public UnityEvent onRightTriggerPressed;
    private void Update()
    {
        if (checkRightTigger)
        {
            if (InputBridge.Instance.RightTriggerDown)
            {
                checkRightTigger = false;
                onRightTriggerPressed.Invoke();
                checkRightTriggerUp = true;
            }
        }

        if (InputBridge.Instance.RightTriggerUp && checkRightTriggerUp)
        {
            checkRightTriggerUp = false;
            onRightTriggerRevoked.Invoke();
            checkRightTigger = true;
        }
    }
    public void CheckTriggerDown()
    {
        checkRightTigger = true;
    }
}
