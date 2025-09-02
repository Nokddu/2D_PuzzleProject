using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Management;

public class GameManager : SingletonGameObject<GameManager>
{
    public static GameManager Ins => Instance;
    public List<bool> GameCleared = new List<bool>();
    public int HP;


    protected override void Awake()
    {
        base.Awake();
        SaveData save = DataManager.Ins.LoadGameData();

        if (save != null)
        {
            GameCleared = new List<bool>(save.isClear);
        }
    }


    /// <summary>
    /// ���� �� �ϳ� Ŭ���� �ϸ� �ε��� Ex) 0 ,1 �ֱ�
    /// </summary>
    /// <param name="GameIndex"></param>
    public void PuzzleClear(int GameIndex)
    {
        GameCleared[GameIndex] = true;
        SaveData saveData = new SaveData();
        saveData.isClear = GameCleared;
        DataManager.Ins.SaveGameData(saveData);
    }

    /// <summary>
    /// ���� Ŭ���� �ߴ��� Ȯ���ϴ� �Լ�
    /// </summary>
    /// <returns></returns>
    public bool IsGameClear()
    {
        foreach (var clear in GameCleared)
        {
            if (clear == false)
            {
                return false;
            }
        }

        return true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
    }

    public void ResetGame()
    {
       int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
