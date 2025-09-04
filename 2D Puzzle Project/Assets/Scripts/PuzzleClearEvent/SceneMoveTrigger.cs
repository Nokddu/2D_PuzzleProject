using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneMoveTrigger : MonoBehaviour
{
    [SerializeField] private int sceneNum;

    [SerializeField] private bool isExit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if(isExit)
        {
            QuitGame();
        }

        if (sceneNum >= 0 && sceneNum < SceneManager.sceneCountInBuildSettings)
        {
            DataManager.SaveGameData();
            SceneManager.LoadScene(sceneNum);
        }
        else
        {
            Debug.LogError("SceneNum Scene�� BuildSetting�� ������������");
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; 
#else
        Application.Quit(); // ���忡���� ���� ����
#endif
    }
}
