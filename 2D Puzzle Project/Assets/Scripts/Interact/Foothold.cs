using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold : MonoBehaviour
{
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Foothold[] otherFootholds;
    [SerializeField] private Door connectedDoor;
    [SerializeField] private DoorType doorType;

    private bool isOn = false;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = offSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if(isOn)
        {
            FootholdOff();
        }
        else
        {
            FootholdOn();
        }
    }

    private void FootholdOn()
    {
        isOn = true;
        spriteRenderer.sprite = onSprite;

        for(int i = 0; i  < otherFootholds.Length; i++)
        {
            if(otherFootholds[i] != null)
            {
                otherFootholds[i].FootholdOff();
            }
        }

        if(connectedDoor != null)
        {
            connectedDoor.SetDoorType(doorType);
            connectedDoor.OpenDoor();
        }

    }

    private void FootholdOff()
    {
        isOn = false;
        spriteRenderer.sprite = offSprite;

        if(connectedDoor != null)
        {
            connectedDoor.CloseDoor();
        }
    }
}
