using JetBrains.Annotations;
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
    [SerializeField] private SceneMoveTrigger scenePortal;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer doorLight;
    [SerializeField] private DoorType doorType;


    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        CloseDoor();   
    }

    public void OpenDoor()
    {
        SoundManager.Ins.PlaySound("EventOn");
        spriteRenderer.sprite = openDoor;

        switch(doorType)
        {
            case DoorType.Normal:
                EnablePortal(true);
                break;
            case DoorType.NextStage:
                doorLight.color = Color.green;
                EnablePortal(true);
                break;
            case DoorType.ExitGame:
                doorLight.color = Color.red;
                EnablePortal(true);
                break;
        }
    }

    public void CloseDoor()
    {
        SoundManager.Ins.PlaySound("EventOn");

        spriteRenderer.sprite = closeDoor;

        EnablePortal(false);
    }

    private void EnablePortal(bool isEnable)
    {
        if(scenePortal != null)
        {
            var col = scenePortal.GetComponent<BoxCollider2D>();
            if (col != null)
                col.enabled = isEnable;
        }
    }
}


