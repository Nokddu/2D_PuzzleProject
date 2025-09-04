using System.Collections;
using System.Collections.Generic;
using System.IO;
using Utils.Management;
using UnityEngine;
using System;

public class DataManager : Singleton<DataManager>
{
    private DataManager()
    {

    }



    private void SaveGameData_Internal(SaveData saveData)
    {

        saveData.hp = GameManager.Ins.HP; // ���߿� �÷��̾� ü���̶� �����Ұ�.

        string json = JsonUtility.ToJson(saveData,true);

        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");

        File.WriteAllText(path, json);

        Debug.Log(path);
    }

    private SaveData LoadGameData_Internal()
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

    private void ResetData_Internal()
    {
        SaveData newData = new SaveData();

        SaveGameData_Internal(newData);
    }

    public static void ResetData()
    {
        Instance.ResetData_Internal();
    }

    public static void SaveGameData(SaveData saveData)
    {
        Instance.SaveGameData_Internal(saveData);
    }

    public static SaveData LoadGameData()
    {
        return Instance.LoadGameData_Internal();
    }
}
