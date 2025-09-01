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

        saveData.hp = 3; // ���߿� �÷��̾� ü���̶� �����Ұ�.

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
            return null;
        }

        string json = File.ReadAllText(path);

        SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

        Debug.Log($"���̺� ������ �ҷ��Խ��ϴ�{loadedData}");
        return loadedData;
    }
}
