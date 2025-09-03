using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetInteract : MonoBehaviour
{
    [SerializeField] private float itemPicradius = 5f;
    [SerializeField] private PlayerItemIcon iconManager;

    [SerializeField] private Item heldItem = null;


    void Start()
    {
        iconManager.UpdateIcon(ItemType.None);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TryInteract();
        }
    }
    private void TryInteract()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, itemPicradius);
        

        foreach(var col in collider)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if(interactable != null)
            {
                interactable.Interact();
            }
            // 아이템 줍기
            Item item = col.GetComponent<Item>();
            if(item != null && heldItem == null)
            {
                heldItem = item;
                item.OnPick();
                iconManager.UpdateIcon(item.GetItemType());
                return;
            }
            // 아이템 놓기
            ItemPlaceSpot spot = col.GetComponent<ItemPlaceSpot>();
            
            if (spot != null && heldItem != null)
            {
                if(spot.GetItem() == null)
                {
                    spot.PlaceItem(heldItem);
                    Debug.Log(spot);
                    heldItem = null;
                    iconManager.UpdateIcon(ItemType.None);
                    return;

                }
                else
                {
                    Item SpotItem = spot.GetItem();
                    spot.PlaceItem(heldItem);
                    heldItem = SpotItem;

                    if(heldItem != null)
                    {
                        heldItem.OnPick();
                    }

                    iconManager.UpdateIcon(heldItem != null ? heldItem.GetItemType() : ItemType.None);
                    return;
                }      
            }
        }
    }
}
