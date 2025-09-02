using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite openDoor;
    [SerializeField] private Sprite closeDoor;
    [SerializeField] private SpriteRenderer doorLight;
    [SerializeField] private Foothold[] foothold;
    [SerializeField] private BoxCollider2D col;

    private SpriteRenderer spriteRenderer;

    public bool isStart;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = closeDoor;
    }

    private void Start()
    {
        if(foothold != null)
        {
            foothold[0].OnSwitchChanged += CheckFootholdChanged;
            foothold[1].OnSwitchChanged += CheckFootholdChanged;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStart)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            GameManager.Ins.ExitGame();
        }
    }

    private void CheckFootholdChanged(bool isOn, bool isMain)
    {
        spriteRenderer.sprite = isOn ? openDoor : closeDoor;
        col.enabled = isOn;
        isStart = isMain;
        if (isMain)
        {
            doorLight.color = Color.white;
        }
        else
        {
            doorLight.color = Color.red;
        }
    }
}
