using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold : MonoBehaviour
{
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Foothold[] otherFootholds;

    private bool isOn = false;
    private SpriteRenderer SpriteRenderer;

    public event Action<bool> OnSwitchChanged;

    private void Awake()
    {
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer.sprite = offSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOn = !isOn;

        SpriteRenderer.sprite = isOn ? onSprite : offSprite;

        if(isOn && otherFootholds.Length > 0)
        {
            foreach(var foothold in otherFootholds)
            {
                foothold.FootholdOff();
            }
        }

        OnSwitchChanged?.Invoke(isOn);

    }

    private void FootholdOff()
    {
        isOn = false;
        SpriteRenderer.sprite = offSprite;

        OnSwitchChanged?.Invoke(isOn);
    }
}
