using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite openDoor;
    [SerializeField] private Sprite closeDoor;

    [SerializeField] private Foothold foothold;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = closeDoor;
    }

    private void Start()
    {
        if(foothold != null)
        {
            foothold.OnSwitchChanged += CheckFootholdChanged;
        }
    }

    private void CheckFootholdChanged(bool isOn)
    {
        spriteRenderer.sprite = isOn ? openDoor : closeDoor;
    }
}
