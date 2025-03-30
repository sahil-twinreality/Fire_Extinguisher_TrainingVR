using UnityEngine;
using UnityEngine.Events;
using BNG;

public class TriggerDownChecker : GrabbableEvents
{
    public bool checkLeftTrigger;
    public bool checkRightTriggerUp;
    public bool checkRightTigger;

    public UnityEvent onLeftTriggerPressed;
    public UnityEvent onRightTriggerRevoked;
    public UnityEvent onRightTriggerPressed;
    public UnityEvent onBothTriggerPressed;
    private void Update()
    {
        if (checkLeftTrigger)
        {
            if (InputBridge.Instance.LeftTriggerDown)
            {
                checkLeftTrigger = false;
                onLeftTriggerPressed.Invoke();
                OnBothButtonsPressed();
            }
        }
        if (checkRightTigger)
        {
            if (InputBridge.Instance.RightTriggerDown)
            {
                checkRightTigger = false;
                onRightTriggerPressed.Invoke();
                OnBothButtonsPressed();
                checkRightTriggerUp = true;
            }
        }

        if (InputBridge.Instance.RightTriggerUp || InputBridge.Instance.LeftTriggerUp)
        {
            checkRightTriggerUp = false;
            onRightTriggerRevoked.Invoke();
            checkRightTigger = true;
            //OnBothButtonsPressed();
        }

        /*if (checkRightTriggerUp)
        {
            
        }*/
    }
    public void CheckTriggerDown()
    {
        checkLeftTrigger = true;
        checkRightTigger = true;
    }

    public void OnBothButtonsPressed()
    {
        if (!checkLeftTrigger && !checkRightTigger)
        {
            onBothTriggerPressed.Invoke();
        }
    }
}
