using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] healthImg;

    private void Start()
    {
        GameManager.Ins.OnHpChanged += UpdateUI;

        UpdateUI(GameManager.Ins.HP);
    }

    private void OnDestroy()
    {
        if(GameManager.Ins != null)
        {
            GameManager.Ins.OnHpChanged -= UpdateUI;
        }
    }

    private void UpdateUI(int hp)
    {
        for(int i = 0; i < healthImg.Length; i++)
        {
            if(i < hp)
            {
                healthImg[i].color = Color.white;
            }
            else
            {
                Color color = Color.white;
                color.a = 0.3f;
                healthImg[i].color = color;
            }
        }
    }
}
