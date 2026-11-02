using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SaveNLoadManager : MonoBehaviour
{
    public PlayerData playerData;
    public void PlayerData()
    {
        if (playerData == null)
        {
            playerData = ScriptableObject.CreateInstance<PlayerData>();
            LoadData();
        }
    }

    public void SaveData()
    {        
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/playerInfo.json", json);
        Debug.Log("Saved Game");
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/playerInfo.json");
            PlayerData loadData = ScriptableObject.CreateInstance<PlayerData>();
            JsonUtility.FromJsonOverwrite(json, loadData);

            playerData = loadData;
            Debug.Log("Loaded Game");
        }
        else
        {
            playerData.ResetData();
            return;
        }
    }
}

