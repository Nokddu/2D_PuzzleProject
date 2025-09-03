using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemIcon : MonoBehaviour
{
    [SerializeField] private GameObject duckIcon;   
    [SerializeField] private GameObject bookIcon;   
    [SerializeField] private GameObject redBallIcon;

    [Header("Z키")]
    [SerializeField] private GameObject ZIcon;

    private void Start()
    {
        duckIcon.SetActive(false);
        bookIcon.SetActive(false);
        redBallIcon.SetActive(false);
    }
    public void UpdateIcon(ItemType type)
    {
        //해당 아이콘 키깃
        switch (type)
        {
            case ItemType.Duck:
                duckIcon.SetActive(true);
                break;
            case ItemType.Book:
                bookIcon.SetActive(true);
                break;
            case ItemType.RedBall:
                redBallIcon.SetActive(true);
                break;
            case ItemType.None:
                duckIcon.SetActive(false);
                bookIcon.SetActive(false);
                redBallIcon.SetActive(false);
                Debug.Log("아이콘 초기화");
                break;
        }
    }
    // 특정 위치에 콜라이더가 닿았을 때 Z 켜주기
    public void ShowZIcon(bool isOn)
    {
        ZIcon.SetActive(isOn);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interection"))
        {
            ShowZIcon(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interection"))
        {
            ShowZIcon(false);
        }
    }
}
