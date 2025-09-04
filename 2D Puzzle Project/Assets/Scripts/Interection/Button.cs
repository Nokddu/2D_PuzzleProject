using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private float ButtonCheckRadius = 3f;
    [SerializeField] protected ChairManager chair;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject failedImg;

    private void Awake()
    {
        if (GameManager.Ins.GameCleared[0] == true)
        {
            wall.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (chair.CheckChairs())
        {
            Debug.Log("정답");
            // 정답이다 연금술사
            GameManager.Ins.PuzzleClear(0);
            wall.SetActive(false);
        }
        else
        {
            Debug.Log("오답");

            StartCoroutine("showImage");
        }
    }

    IEnumerator showImage()
    {
        wall.SetActive(false);
        failedImg.SetActive(true);
        yield return new WaitForSeconds(2f);
        GameManager.Ins.ResetGame();
    }
}
