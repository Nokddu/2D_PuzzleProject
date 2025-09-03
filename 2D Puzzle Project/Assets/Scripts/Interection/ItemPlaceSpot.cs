using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceSpot : MonoBehaviour
{
    private Chair placedChair;
    private Item placedItem;
    public Item PlcedItem => placedItem;
    public bool HasItem => placedItem != null;
    public bool IsPlaced => placedChair != null;

    [SerializeField] private Transform placePoint;

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
        Debug.Log("¾È³ç");
        Item temp = placedItem;
        placedItem = null;
        return temp;
    }
}
