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
    /// 퍼즐 방 하나 클리어 하면 인덱스 Ex) 0 ,1 넣기
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
    /// 게임 클리어 했는지 확인하는 함수
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
