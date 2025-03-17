using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class FireTriangleManager : MonoBehaviour
{
    public bool HeatEventCompleted;
    public bool OxygenEventCompleted;
    public bool FuelEventCompleted;
    public float DelayOnEventCompletion;

    public UnityEvent onFireTriangleComplete;

    public void EventComplete(string eventName)
    {
        if(eventName == "Heat")
        {
            HeatEventCompleted = true;
        }
        else if(eventName == "Oxygen")
        {
            OxygenEventCompleted = true;
        }
        else if (eventName == "Fuel")
        {
            FuelEventCompleted = true;
        }

        StartCoroutine(CheckEventCompletion());
    }

    IEnumerator CheckEventCompletion()
    {
        if (HeatEventCompleted && OxygenEventCompleted && FuelEventCompleted)
        {
            yield return new WaitForSeconds(DelayOnEventCompletion);
            onFireTriangleComplete.Invoke();
        }
    }
}
