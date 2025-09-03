using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] private float ButtonCheckRadius = 3f;
    [SerializeField] private ChairManager chair;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject failedImg;
    private void Awake()
    {
        if (GameManager.Ins.GameCleared[0] == true)
        {
            wall.SetActive(false);
        }
    }

    public void Interact()
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

            chair.ResetChairs();
        }
    }

    IEnumerator showImage()
    {
        wall.SetActive(false);
        failedImg.SetActive(true);
        yield return new WaitForSeconds(5f);
        failedImg.SetActive(false);
        wall.SetActive(true);
    }

    public void TryCheck()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, ButtonCheckRadius);

        foreach (var col in collider)
        {
            
        }
    }
}
