using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chap1Clear : BaseChapClear
{
    [SerializeField] private GameObject secretDoor;
    [SerializeField] private ItemPlaceSpot itemPlaceSpot;
    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;

    private Item lastCheckItem = null;
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

    private void TryOpenDoorWithItem(Item item)
    {
        if (item == null)
        {
            leftDoor.CloseDoor();
            rightDoor.CloseDoor();
            return;
        }

        switch(item.GetItemType())
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
