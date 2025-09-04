using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chap1Clear : BaseChapClear
{
    [SerializeField] private GameObject secretDoor;
    [SerializeField] private ItemPlaceSpot itemPlaceSpot;
    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;

    private ItemType lastCheckItem = ItemType.None;
    private void Start()
    {
        if(secretDoor != null)
        {
            secretDoor.SetActive(false);
        }       
    }

    private void Update()
    {
        var item = itemPlaceSpot.placedItem;

        if(item != lastCheckItem)
        {
            lastCheckItem = item;
            TryOpenDoorWithItem(item);
        }
    }

    public override void ClearEvent()
    {
        if(secretDoor != null)
        {
            secretDoor.SetActive(true);
        }        
    }

    private void TryOpenDoorWithItem(ItemType itemtype)
    {
        if (itemtype == ItemType.None)
        {
            leftDoor.CloseDoor();
            rightDoor.CloseDoor();
            return;
        }

        switch(itemtype)
        {
            case ItemType.Duck:
                leftDoor.OpenDoor();
                rightDoor.CloseDoor();
                break;
            case ItemType.RedBall:
                leftDoor.CloseDoor();
                rightDoor.OpenDoor();
                break;

            case ItemType.OpenBook:
                leftDoor.CloseDoor();
                rightDoor.CloseDoor();
                ClearEvent();
                break;

            default:
                leftDoor.CloseDoor();
                rightDoor.CloseDoor();
                break;
        }
    }
}
