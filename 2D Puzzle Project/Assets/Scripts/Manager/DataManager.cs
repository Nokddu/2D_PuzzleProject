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

    public void SaveGameData()
    {
        SaveData saveData = new SaveData();

        saveData.hp = 3; // ���߿� �÷��̾� ü���̶� �����Ұ�.

        saveData.isClear = GameManager.Ins.GameCleared;

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
            Debug.Log($"���̺� ������ �����ϴ�.{path}�� ���̺� ���� ����");
            return new SaveData();
        }

        string json = File.ReadAllText(path);

        SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

        Debug.Log($"���̺� ������ �ҷ��Խ��ϴ�{loadedData}");
        return loadedData;
    }
}
