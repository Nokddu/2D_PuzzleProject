using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemIcon : MonoBehaviour
{
    [SerializeField] private GameObject duckIcon;   
    [SerializeField] private GameObject bookIcon;   
    [SerializeField] private GameObject redBallIcon;
    [SerializeField] private GameObject openbookIcon;
    
    [Header("ZŰ")]
    [SerializeField] private GameObject ZIcon;

    [SerializeField] private List<GameObject> items = new();

    private void Start()
    {
        duckIcon.SetActive(false);
        bookIcon.SetActive(false);
        redBallIcon.SetActive(false);
    }
    public void UpdateIcon(ItemType type)
    {
        ItemType = type;
        //�ش� ������ Ű��
        switch (type)
        {
            case ItemType.Duck:
                duckIcon.SetActive(true);
                bookIcon.SetActive(false);
                redBallIcon.SetActive(false);
                openbookIcon.SetActive(false);
                break;
            case ItemType.Book:
                duckIcon.SetActive(false);
                bookIcon.SetActive(true);
                redBallIcon.SetActive(false);
                openbookIcon.SetActive(false);
                break;
            case ItemType.RedBall:
                duckIcon.SetActive(false);
                bookIcon.SetActive(false);
                redBallIcon.SetActive(true);
                openbookIcon.SetActive(false);
                break;
            case ItemType.OpenBook:
                duckIcon.SetActive(false);
                bookIcon.SetActive(false);
                redBallIcon.SetActive(false);
                openbookIcon.SetActive(true);
                break;
            case ItemType.None:
                duckIcon.SetActive(false);
                bookIcon.SetActive(false);
                redBallIcon.SetActive(false);
                openbookIcon.SetActive(false);
                Debug.Log("������ �ʱ�ȭ");
                break;
        }
    }
    // Ư�� ��ġ�� �ݶ��̴��� ����� �� Z ���ֱ�
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

    public ItemType ItemType { get; set; }
}
