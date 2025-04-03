using UnityEngine;

public class Pass_Prefs_Data : MonoBehaviour
{
    private string prefsName;
    //public TMPro.TMP_Text text;

    public void SaveData(string prefSaveName)
    {
        PlayerData.Instance.SaveData(prefSaveName);
        //text.text = prefSaveName + ": " +  PlayerPrefs.GetInt(prefSaveName + "_eventCompleted", 0);
    }
}
