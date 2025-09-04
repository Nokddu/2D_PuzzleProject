using System.Collections.Generic;
using UnityEngine;
using Backend.Object.Character;
using Backend.Util.Extension;

public class PlayerGetInteract : MonoBehaviour
{
    [SerializeField] private float itemPicradius = 5f;
    [SerializeField] private PlayerItemIcon iconManager;

    [SerializeField] private LayerMask mask01;
    [SerializeField] private LayerMask mask02;

    private Queue<Item> _items;
    private Collider2D[] _hits01;
    private Collider2D[] _hits02;

    private PlayerCharacterMovementController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerCharacterMovementController>();

        _items = new Queue<Item>();
        _hits01 = new Collider2D[1];
        _hits02 = new Collider2D[1];
    }

    private void Start()
    {
        iconManager.UpdateIcon(ItemType.None);
    }

    private void Update()
    {
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
        var a = Physics2D.OverlapCircleNonAlloc(position, 5f, _hits01, mask01);
        var b = Physics2D.OverlapCircleNonAlloc(position, 5f, _hits02, mask02);
        var length = a + b;
        
        switch (length)
        {
            case 1:
                var itemObject = _hits01[0].gameObject;
                if (itemObject.HasComponent<Item>())
                {
                    Pick(itemObject);
                }
                else
                {
                    Drop(itemObject);
                }
                break;
            case 2:
                Pick(_hits01[0].gameObject);
                Drop(_hits02[0].gameObject);
                break;
        }
    }

    private void Pick(GameObject itemObject)
    {
        var item = itemObject.GetComponent<Item>();
        
        _items.Enqueue(item);

        item.OnPick();
        iconManager.UpdateIcon(item.GetItemType());
    }

    private void Drop(GameObject placementObject)
    {
        var position = placementObject.transform.position;
        
        var item = _items.Dequeue();
        item.OnPlace(position);

        if (_items.Count == 0)
        {
            iconManager.UpdateIcon(ItemType.None);
        }
    }
}
