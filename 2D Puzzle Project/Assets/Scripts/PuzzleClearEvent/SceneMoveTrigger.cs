using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneMoveTrigger : MonoBehaviour
{
    [SerializeField] private int sceneNum; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (sceneNum >= 0 && sceneNum < SceneManager.sceneCountInBuildSettings)
        {
            DataManager.SaveGameData();
            SceneManager.LoadScene(sceneNum);
        }
        else
        {
            Debug.LogError("SceneNum Scene이 BuildSetting에 존재하지않음");
        }
    }
}
