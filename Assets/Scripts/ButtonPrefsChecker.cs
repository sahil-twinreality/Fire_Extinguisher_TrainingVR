using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefsChecker : MonoBehaviour
{
    public bool isEventCompleted;
    public RawImage TickImg;
    public string prefsName;

    private void Start()
    {
        isEventCompleted = PlayerPrefs.GetInt(prefsName + "_eventCompleted", 0) == 1;

        if(isEventCompleted)
        {
            TickImg.gameObject.SetActive(true);
        }
        else
        {
            TickImg.gameObject.SetActive(false);
        }
    }

    /*public void CompleteEvent()
    {
        isEventCompleted = true;
        PlayerPrefs.SetInt(gameObject.name + "_eventCompleted", 1);
        PlayerPrefs.Save();
    }*/

    public void ReloadData()
    {
        isEventCompleted = PlayerPrefs.GetInt(prefsName + "_eventCompleted", 0) == 1;

        if (isEventCompleted)
        {
            TickImg.gameObject.SetActive(true);
        }
        else
        {
            TickImg.gameObject.SetActive(false);
        }
    }
}
