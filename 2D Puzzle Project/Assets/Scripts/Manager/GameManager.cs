using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Management;

public class GameManager : SingletonGameObject<GameManager>
{
    public static GameManager Ins => Instance;
    public List<bool> GameCleared { get => DataManager.SaveData.isClear; set => DataManager.SaveData.isClear = value; }

    [SerializeField] private List<Item> items = new();

    public int HP
    {
        get => DataManager.SaveData.hp;
        set
        {
            DataManager.SaveData.hp = Mathf.Clamp(value, 0, 3);
            OnHpChanged?.Invoke(DataManager.SaveData.hp);
        }
    }

    public event Action<int> OnHpChanged;

    protected override void Awake()
    {
        base.Awake();
        DataManager.LoadGameData();
    }

    /// <summary>
    /// 퍼즐 방 하나 클리어 하면 인덱스 Ex) 0 ,1 넣기
    /// </summary>
    /// <param name="GameIndex"></param>
    public void PuzzleClear(int GameIndex)
    {
        GameCleared[GameIndex] = true;
        DataManager.SaveData.isClear = GameCleared;
        DataManager.SaveGameData();
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void GameOver()
    {
        HP = 3;
        DataManager.ResetData();
        ExitGame();
    }
    public Item GetItemByType(ItemType itemType)
    {
        Item item = null;

        switch(itemType)
        {
            case ItemType.None:
                break;
            case ItemType.Book:
                item = items[0];
                break;
            case ItemType.Duck:
                item = items[1];
                break;
            case ItemType.OpenBook:
                item = items[2];
                break;
            case ItemType.RedBall:
                item = items[3];
                break;             
        }
        return item;
    }
    public static ItemType ItemType { get => DataManager.SaveData.type; set => DataManager.SaveData.type = value; }


}
