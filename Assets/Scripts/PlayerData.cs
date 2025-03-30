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
    //public ButtonPrefsChecker[] prefsCheckers;
    public UnityEvent onAllSceneCompleted;
    public UnityEvent onFireTriangleCompleted;
    public UnityEvent onFireClassCompleted;
    public UnityEvent onExtClassCompleted;
    public UnityEvent onPassClassCompleted;

    private string playerNameKey = "playerName";

    public static PlayerData Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(!dataInputed)
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
        }

        if(dataInputed)
        {
            onDataInputed.Invoke();
        }
        //PlayerPrefs.DeleteAll();

        // Load progress from PlayerPrefs
        Invoke("CheckMenuData", 0.5f);
    }

    public void CheckMenuData()
    {
        dataInputed = true;
        Debug.Log("Checking Menu Data...");

        if (PlayerPrefs.GetInt("Fire_Triangle_eventCompleted", 0) == 1)
        {
            Debug.Log("Fire Triangle Completed!");
            onFireTriangleCompleted.Invoke();
        }

        if (PlayerPrefs.GetInt("Extinguisher_Class_eventCompleted", 0) == 1)
        {
            Debug.Log("Extinguisher Class Completed!");
            onExtClassCompleted.Invoke();
        }

        if (PlayerPrefs.GetInt("Fire_Class_eventCompleted", 0) == 1)
        {
            Debug.Log("Fire Class Completed!");
            onFireClassCompleted.Invoke();
        }

        if (PlayerPrefs.GetInt("PASS_eventCompleted", 0) == 1)
        {
            Debug.Log("PASS Class Completed!");
            onPassClassCompleted.Invoke();
        }

        if(PlayerPrefs.GetInt("Fire_Triangle_eventCompleted", 0) == 1 && PlayerPrefs.GetInt("Extinguisher_Class_eventCompleted", 0) == 1 && PlayerPrefs.GetInt("Fire_Class_eventCompleted", 0) == 1 && PlayerPrefs.GetInt("PASS_eventCompleted", 0) == 1)
        {
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

    public void SaveData(string prefSaveName)
    {
        PlayerPrefs.SetInt(prefSaveName + "_eventCompleted", 1);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt(prefSaveName + "_eventCompleted", 0));
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

    /*public void ReloadData()
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
    }*/

    public void EnterCertificateName(TMPro.TMP_Text text)
    {
        text.text = PlayerPrefs.GetString(playerNameKey, "");
    }

    public void EnterCertificateDate(TMPro.TMP_Text text)
    {
        DateTime today = DateTime.Today;
        text.text = today.ToShortDateString();
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
