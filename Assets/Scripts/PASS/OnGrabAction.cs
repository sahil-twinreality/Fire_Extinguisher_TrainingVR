using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

public class OnGrabAction : GrabbableEvents
{
    public UnityEvent OnObjectGrab;
    public UnityEvent OnObjectThrown;
    public bool objectGrabbed;

    public void OnTriggerStay(Collider other)
    {
        if (InputBridge.Instance.LeftTrigger > 0.2f || InputBridge.Instance.RightTrigger > 0.2f)
        {
            OnObjectGrab.Invoke();
        }
    }
}