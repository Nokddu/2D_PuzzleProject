using Backend.Object.Character;
using Backend.Util.Extension;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGetInteract : MonoBehaviour
{
    [SerializeField] private float itemPicradius = 5f;
    [SerializeField] private PlayerItemIcon iconManager;

    [SerializeField] private LayerMask mask01;
    [SerializeField] private LayerMask mask02;

    [SerializeField] private int count;

    private Queue<ItemType> _items;
    private Collider2D[] _hits01;
    private Collider2D[] _hits02;

    private PlayerCharacterMovementController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerCharacterMovementController>();

        _items = new Queue<ItemType>();
        _hits01 = new Collider2D[1];
        _hits02 = new Collider2D[1];
    }

    private void Start()
    {
        DataManager.LoadGameData();
        var type = DataManager.SaveData.type;
        iconManager.UpdateIcon(DataManager.SaveData.type);

        if(type != ItemType.None)
        {
            _items.Enqueue(DataManager.SaveData.type);
        }     
    }

    private void Update()
    {
        count = _items.Count;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    private void Interact()
    {
        var position = transform.position;
        var direction = _controller.Forward;
        var size = new Vector2(1f, 1f);
        var a = Physics2D.Raycast(position, direction, 1f, mask01);
        var b = Physics2D.Raycast(position, direction, 1f, mask02);
        var length = (a ? 1 : 0) + (b ? 1 : 0);
        Debug.Log($"{(a ? 1 : 0)}. {(b ? 1:0)}");
        switch (length)
        {
            case 1:
                if (a && _items.Count == 0)
                {
                    Pick(a.collider.gameObject);
                }
                else if(b && _items.Count == 1)
                {
                    Drop(b.collider.gameObject);
                }
                break;
            case 2:
                if (_items.Count == 1)
                {
                    Drop(b.collider.gameObject);
                    Pick(a.collider.gameObject);
                }
                else if (_items.Count == 0)
                {
                    Pick(a.collider.gameObject);
                    
                }
                break;
        }
        DataManager.SaveData.type = iconManager.ItemType;
        DataManager.SaveGameData();
    }

    private void Pick(GameObject itemObject)
    {
        var item = itemObject.GetComponent<Item>();

        _items.Enqueue(item.GetItemType()); 

        //item.OnPick();
        iconManager.UpdateIcon(item.GetItemType());
        Destroy(itemObject);
    }

    private void Drop(GameObject placementObject)
    {
        Debug.Log("넘어가니");
        var position = placementObject.transform.position;
        var place = placementObject.gameObject.GetComponent<ItemPlaceSpot>();
        var item = _items.Dequeue();
        Instantiate(GameManager.Ins.GetItemByType(item)).transform.position = position;
        place.PlaceItem(item);

        if (_items.Count == 0)
        {
            iconManager.UpdateIcon(ItemType.None);
        }
    }
}
