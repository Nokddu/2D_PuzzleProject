using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] GameObject Button01;
    [SerializeField] GameObject Button02;

    private void Awake()
    {
        if (DataManager.SaveData.isClear[0] == true)
        {
            Button01.SetActive(true);
            Button02.SetActive(true);
        }
    }
}
