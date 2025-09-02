using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public int SceneNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveScenes();
    }

    public void MoveScenes()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
