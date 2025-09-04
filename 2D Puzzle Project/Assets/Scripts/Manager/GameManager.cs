using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Management;

public class GameManager : SingletonGameObject<GameManager>
{
    public static GameManager Ins => Instance;
    public List<bool> GameCleared = new List<bool>();

    [SerializeField] private int hp;
    public int HP
    {
        get => hp;
        set
        {
            hp = Mathf.Clamp(value, 0, 3);
            OnHpChanged?.Invoke(hp);
        }
    }

    public event Action<int> OnHpChanged;

    protected override void Awake()
    {
        base.Awake();
        SaveData save = DataManager.LoadGameData();

        if (save != null)
        {
            GameCleared = new List<bool>(save.isClear);
            hp = save.hp;
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
        DataManager.SaveGameData(saveData);
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

    public void GameOver()
    {
        hp = 3;
        DataManager.ResetData();
        ExitGame();
    }

    private void Update() //�׽�Ʈ��
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            HP--;
        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            HP++;
        }
    }
}
