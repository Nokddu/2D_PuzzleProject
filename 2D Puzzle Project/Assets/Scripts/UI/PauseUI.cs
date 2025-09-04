using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Image toggleImg;
    [SerializeField] private Sprite resumeSprite;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private GameObject pauseText;

    private bool isPause = false;

    public void PauseOrResume()
    {
        isPause = !isPause;


        if(!isPause)
        {
            toggleImg.sprite = resumeSprite;
            GameManager.Ins.PlayGame();
            pauseText.SetActive(false);
        }
        else if(isPause)
        {
            Debug.Log("3¹ø¾À Ã¼Å©");
            toggleImg.sprite = pauseSprite;
            GameManager.Ins.PauseGame();
            pauseText.SetActive(true);
        }
    }
}
