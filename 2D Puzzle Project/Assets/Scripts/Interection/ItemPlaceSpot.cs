using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceSpot : MonoBehaviour
{
    private Chair placedChair;
    public ItemType placedItem;
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

    public void PlaceItem(ItemType itemtype)
    {
        placedItem = itemtype;
        Debug.Log(placedItem);
    }
}
