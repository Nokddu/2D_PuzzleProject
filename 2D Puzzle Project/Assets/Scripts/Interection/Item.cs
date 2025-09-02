using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemtype;
    
    // 상호작용시 호출 함수
    public ItemType GetItemType()
    {
        return itemtype;
    }
    //플레이어가 아이템을 집을 때 호추우울
    public void OnPick()
    {
        gameObject.SetActive(false);
    }
    //플레이어가 내려놓을 때애애
    public void OnPlace(Vector3 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);

    }
    public void ResetPosition()
    {

    }
}
