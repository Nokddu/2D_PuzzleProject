using System.Collections;
using System.Collections.Generic;
using System.IO;
using Utils.Management;
using UnityEngine;
using System;

public class DataManager : Singleton<DataManager>
{ 
    public static SaveData SaveData { get; set; }

    private DataManager()
    {
        
    }

    private void SaveGameData_Internal()
    {

        SaveData.hp = GameManager.Ins.HP; // 나중에 플레이어 체력이랑 연결할것.

        SaveData.type = GameManager.ItemType;

        string json = JsonUtility.ToJson(SaveData,true);

        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");

        File.WriteAllText(path, json);

        Debug.Log(path);
    }

    private void LoadGameData_Internal()
    {
        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");

        if (!File.Exists(path))
        {
            Debug.Log($"세이브 파일이 없습니다.{path}에 세이브 파일 생성");
            SaveData = new SaveData();
        }

        string json = File.ReadAllText(path);

        SaveData = JsonUtility.FromJson<SaveData>(json);

        Debug.Log($"세이브 파일을 불러왔습니다{SaveData}");
    }

    private void ResetData_Internal()
    {
        SaveData = new SaveData();

        SaveGameData_Internal();
    }

    public static void ResetData()
    {
        Instance.ResetData_Internal();
    }

    public static void SaveGameData()
    {
        Instance.SaveGameData_Internal();
    }

    public static void LoadGameData()
    {
        Instance.LoadGameData_Internal();
    }
}
