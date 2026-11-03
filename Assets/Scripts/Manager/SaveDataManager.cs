using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public PlayerData playerData;

    public void ResetData()
    {
        playerData.ResetData();
    }
}

public class SaveDataManager : MonoBehaviour
{
    public SaveData currentSaveData;
    public void PlayerData()
    {
        if (currentSaveData == null)
        {
            currentSaveData = new SaveData();
            if(currentSaveData.playerData == null)
            {
                currentSaveData.playerData = ScriptableObject.CreateInstance<PlayerData>();
            }
            LoadData();
        }

        
    }

    public void SaveData()
    {
        SaveData saveData = new SaveData();
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/playerInfo.json", json);
        Debug.Log("Saved Game");
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/playerInfo.json");
            SaveData loadData = new SaveData();
            JsonUtility.FromJsonOverwrite(json, loadData);

            currentSaveData = loadData;
            Debug.Log("Loaded Game");
        }
        else
        {
            currentSaveData.ResetData();
            return;
        }
    }
}

