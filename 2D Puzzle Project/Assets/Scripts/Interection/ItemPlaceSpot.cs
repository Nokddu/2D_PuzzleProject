using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceSpot : MonoBehaviour
{
    private Chair placedChair;
    private Item placedItem;
    public bool HasItem => placedItem != null;
    public bool IsPlaced => placedChair != null;

    [SerializeField] private Transform placePoint;

    [SerializeField] private bool hasItemDebug; //체크용 추후삭제

    public Item PlacedItem => placedItem;

    private void Update()
    {
        hasItemDebug = HasItem;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Chair chair = collision.GetComponent<Chair>();
        if(chair != null)
        {
            placedChair = chair;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Chair chair = collision.GetComponent<Chair>();
        if(chair != null && chair == placedChair)
        {
            placedChair = null;
        }
    }

    public void PlaceItem(Item item)
    {
        placedItem = item;
        item.transform.position = transform.position;
        item.gameObject.SetActive(true);
        Debug.Log(placedItem);
    }

    public Item GetItem()
    {
        if (placedItem == null) return null;
        Debug.Log("안녕");
        Item temp = placedItem;
        placedItem = null;
        return temp;
    }
}
