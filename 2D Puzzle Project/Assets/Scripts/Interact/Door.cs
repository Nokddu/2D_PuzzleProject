using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum DoorType
{
    Normal,
    NextStage,
    ExitGame
}
public class Door : MonoBehaviour
{
    [SerializeField] private Sprite openDoor;
    [SerializeField] private Sprite closeDoor;
    [SerializeField] private SceneMoveTrigger[] scenePortals;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer doorLight;
    [SerializeField] private DoorType currentDoorType = DoorType.Normal;


    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        CloseDoor();   
    }

    public void SetDoorType(DoorType newType)
    {
        currentDoorType = newType;
    }
    public void OpenDoor()
    {
        SoundManager.Ins.PlaySound("EventOn");
        spriteRenderer.sprite = openDoor;

        switch(currentDoorType)
        {
            case DoorType.Normal:
                EnablePortal(0, true);
                break;
            case DoorType.NextStage:
                doorLight.color = Color.green;
                EnablePortal(0, true);
                EnablePortal(1, false);
                break;
            case DoorType.ExitGame:
                doorLight.color = Color.red;
                EnablePortal(0, false);
                EnablePortal(1, true);
                break;
        }
    }

    public void CloseDoor()
    {
        SoundManager.Ins.PlaySound("EventOn");

        spriteRenderer.sprite = closeDoor;

        foreach (var portal in scenePortals)
            EnableCollider(portal, false);
    }

    private void EnablePortal(int index, bool isEnable)
    {
        if (scenePortals != null && index < scenePortals.Length && scenePortals[index] != null)
            EnableCollider(scenePortals[index], isEnable);
    }

    private void EnableCollider(SceneMoveTrigger portal, bool isEnable)
    {
        var col = portal.GetComponent<BoxCollider2D>();
        if (col != null)
            col.enabled = isEnable;
    }
}


