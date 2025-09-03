using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite openDoor;
    [SerializeField] private Sprite closeDoor;
    [SerializeField] private SceneMoveTrigger scenePortal;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isStartDoor;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        CloseDoor();
    }

    public void OpenDoor()
    {
        if(isStartDoor)
        {
            spriteRenderer.color = Color.green;
        }
        spriteRenderer.sprite = openDoor;

        if (scenePortal != null)
        {
            var col = scenePortal.GetComponent<BoxCollider2D>();
            if (col != null)
                col.enabled = true;  
        }
    }

    public void CloseDoor()
    {
        if(isStartDoor)
        {
            spriteRenderer.color = Color.red;
        }
        spriteRenderer.sprite = closeDoor;

        if (scenePortal != null)
        {
            var col = scenePortal.GetComponent<BoxCollider2D>();
            if (col != null)
                col.enabled = false;
        }
    } 
}
