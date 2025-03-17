using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timer;
    public TMP_Text timeText;
    public string customTextBeforeTimer;

    public UnityEvent OnTimerFinished;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            string timeString = string.Format("{0:00}", seconds);

            timeText.text = customTextBeforeTimer + timeString;
        }
        else if (timer < 0)
        {
            timeText.text = "00";
            timer = 0;
            OnTimerFinished.Invoke();
        }
    }
}
