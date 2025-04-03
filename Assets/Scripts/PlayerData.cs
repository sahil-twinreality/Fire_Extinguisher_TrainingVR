using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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

        if (dataInputed)
        {
            onDataInputed.Invoke();
            inputName.text = playerName;
        }
        Invoke("CheckMenuData", 0.5f);
    }

    public void CheckMenuData()
    {
        dataInputed = true;

        if (PlayerPrefs.GetInt("Fire_Triangle_eventCompleted", 0) == 1)
        {
            onFireTriangleCompleted.Invoke();
        }

        if (PlayerPrefs.GetInt("Extinguisher_Class_eventCompleted", 0) == 1)
        {
            onExtClassCompleted.Invoke();
        }

        if (PlayerPrefs.GetInt("Fire_Class_eventCompleted", 0) == 1)
        {
            onFireClassCompleted.Invoke();
        }

        if (PlayerPrefs.GetInt("PASS_eventCompleted", 0) == 1)
        {
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
        PlayerPrefs.Save();

        dataInputed = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void QuitApp()
    {
        Application.Quit();
    }
}
