using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Management;

public class GameManager : SingletonGameObject<GameManager>
{
    public static GameManager Ins => Instance;
    public List<bool> GameCleared = new List<bool>();
    SaveData save;

    protected override void Awake()
    {
        base.Awake();
        save = DataManager.Ins.LoadGameData();
        GameCleared.Clear();
        GameCleared = save.isClear;
    }


    /// <summary>
    /// 퍼즐 방 하나 클리어 하면 인덱스 Ex) 0 ,1 넣기
    /// </summary>
    /// <param name="GameIndex"></param>
    public void PuzzleClear(int GameIndex)
    {
        GameCleared[GameIndex] = true;
        DataManager.Ins.SaveGameData();
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
}
