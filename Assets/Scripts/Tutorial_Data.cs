using UnityEngine;
using UnityEngine.Events;

public class Tutorial_Data : MonoBehaviour
{
    public GameObject Tutorial;
    public UnityEvent onTutorialStart;
    private bool eventCompleted;
    public bool checkPrefs;

    private void Start()
    {
        if(checkPrefs)
        {
            //eventCompleted = PlayerPrefs.GetInt("eventCompleted", 0) == 1;
            eventCompleted = true;
        }

        if (eventCompleted)
        {
            Tutorial.SetActive(false);
        }
        else
        {
            Tutorial.SetActive(true);
            onTutorialStart.Invoke();
        }
    }

    public void CompleteEvent()
    {
        if(!eventCompleted)
        {
            eventCompleted = true;
            PlayerPrefs.SetInt("eventCompleted", 1);
            PlayerPrefs.Save();
            checkPrefs = true;
        }
    }
}
