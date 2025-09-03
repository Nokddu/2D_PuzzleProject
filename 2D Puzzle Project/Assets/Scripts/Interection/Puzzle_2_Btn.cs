using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_2_Btn : Button
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject failedImg;

    private void Awake()
    {
        if (GameManager.Ins.GameCleared[0] == true)
        {
            wall.SetActive(false);
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (chair.CheckChairs())
        {
            Debug.Log("����");
            // �����̴� ���ݼ���
            GameManager.Ins.PuzzleClear(0);
            wall.SetActive(false);
        }
        else
        {
            Debug.Log("����");

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
