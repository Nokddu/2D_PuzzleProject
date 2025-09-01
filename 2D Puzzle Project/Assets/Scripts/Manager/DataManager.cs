using System.Collections;
using System.Collections.Generic;
using System.IO;
using Utils.Management;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public static DataManager Ins => Instance;

    private DataManager()
    {
       
    }

    public void SaveGameData(SaveData saveData)
    {

        saveData.hp = 3; // 나중에 플레이어 체력이랑 연결할것.

        string json = JsonUtility.ToJson(saveData,true);

        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");

        File.WriteAllText(path, json);

        Debug.Log(path);
    }

    public SaveData LoadGameData()
    {
        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");

        if (!File.Exists(path))
        {
            Debug.Log($"세이브 파일이 없습니다.{path}에 세이브 파일 생성");
            return null;
        }

        string json = File.ReadAllText(path);

        SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

        Debug.Log($"세이브 파일을 불러왔습니다{loadedData}");
        return loadedData;
    }
}
