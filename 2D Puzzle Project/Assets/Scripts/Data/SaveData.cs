using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<bool> isClear;
    public ItemType type;
    public int hp;

    public SaveData()
    {
        isClear = new List<bool>() { false, false };
        type = ItemType.None;
        hp = 3;
    }
}
