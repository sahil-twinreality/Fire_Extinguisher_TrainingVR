using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public InputField inputName;
    public Button newUser;
    public Button oldUser;
    public Canvas keyboard;
    private string playerName;
    private static bool dataInputed;
    public UnityEvent onDataInputed;
    public ButtonPrefsChecker[] prefsCheckers;
    public UnityEvent onAllSceneCompleted;

    private string playerNameKey = "playerName";

    private void Start()
    {
        if (dataInputed)
        {
            onDataInputed.Invoke();
        }
        else
        {
            playerName = PlayerPrefs.GetString(playerNameKey, "");

            if (!string.IsNullOrEmpty(playerName))
            {
                inputName.text = playerName;
                newUser.transform.localPosition = new Vector3(250, -175, 0);
                oldUser.gameObject.SetActive(true);
            }
            else
            {
                oldUser.gameObject.SetActive(true);
                oldUser.transform.localPosition = new Vector3(0, -175, 0);
                newUser.gameObject.SetActive(false);
                keyboard.gameObject.SetActive(true);
                inputName.placeholder.GetComponent<Text>().text = "Please Enter Your Name";
            }

            dataInputed = true;
        }

        Invoke("CheckMenuData", 0.1f);
    }

    private void CheckMenuData()
    {
        bool allCompleted = true;

        foreach (ButtonPrefsChecker buttonPrefs in prefsCheckers)
        {
            if (PlayerPrefs.GetInt(buttonPrefs.name + "_eventCompleted", 0) != 1)
            {
                Debug.Log("Not_Completed");
                allCompleted = false;
                break;
            }
        }

        if (allCompleted)
        {
            Debug.Log("Completed");
            onAllSceneCompleted.Invoke();
        }
    }

    public void SavePlayerData()
    {
        if (inputName != null)
        {
            playerName = inputName.text;
            PlayerPrefs.SetString(playerNameKey, playerName);
            PlayerPrefs.Save();
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        playerName = PlayerPrefs.GetString(playerNameKey, "");
        inputName.placeholder.GetComponent<Text>().text = "Please Enter Your Name";
        inputName.text = null;
        oldUser.gameObject.SetActive(true);
        oldUser.transform.localPosition = new Vector3(0, -175, 0);
        newUser.gameObject.SetActive(false);
        PlayerPrefs.Save();

    }

    public void ReloadData()
    {
        dataInputed = false;
        foreach (ButtonPrefsChecker buttonPrefs in prefsCheckers)
        {
            buttonPrefs.ReloadData();
        }

        if (dataInputed)
        {
            onDataInputed.Invoke();
        }

        else
        {
            playerName = PlayerPrefs.GetString(playerNameKey, "");

            if (!string.IsNullOrEmpty(playerName))
            {
                inputName.text = playerName;
                newUser.transform.localPosition = new Vector3(250, -175, 0);
                oldUser.gameObject.SetActive(true);
            }
            else
            {
                oldUser.gameObject.SetActive(true);
                oldUser.transform.localPosition = new Vector3(0, -175, 0);
                newUser.gameObject.SetActive(false);
                keyboard.gameObject.SetActive(true);
                inputName.placeholder.GetComponent<Text>().text = "Please Enter Your Name";
            }

            dataInputed = true;
        }

        Invoke("CheckMenuData", 0.1f);
    }

    public void EnterCertificateName(TMPro.TMP_Text text)
    {
        text.text = PlayerPrefs.GetString(playerNameKey, "");
    }

    public void EnterCertificateDate(TMPro.TMP_Text text)
    {
        DateTime today = DateTime.Today;
        text.text = today.ToShortDateString();
    }
}
