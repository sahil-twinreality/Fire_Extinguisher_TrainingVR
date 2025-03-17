using UnityEngine;
using UnityEngine.Events;
using BNG;

public class GrabbuttonChecker : GrabbableEvents
{
    public bool checkLeftGrab;
    public bool checkRightGrab;

    public UnityEvent onLeftGrabPressed;
    public UnityEvent onRightGrabPressed;
    public UnityEvent onBothGrabPressed;
    private void Update()
    {
        if(checkLeftGrab)
        {
            if (InputBridge.Instance.LeftGripDown)
            {
                checkLeftGrab = false;
                onLeftGrabPressed.Invoke();
                OnBothButtonsPressed();
            }
        }
        if (checkRightGrab)
        {
            if (InputBridge.Instance.RightGripDown)
            {
                checkRightGrab = false;
                onRightGrabPressed.Invoke();
                OnBothButtonsPressed();
            }
        }
    }
    public void CheckGrab()
    {
        checkLeftGrab = true;
        checkRightGrab = true;
    }

    public void OnBothButtonsPressed()
    {
        if(!checkLeftGrab && !checkRightGrab)
        {
            onBothGrabPressed.Invoke();
        }
    }
}
