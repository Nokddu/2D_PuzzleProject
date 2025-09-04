using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzzle : MonoBehaviour
{
    [SerializeField] private ChairManager chairManager;
    [SerializeField] private ItemPlaceSpot itemPlace;

    [SerializeField] private BaseChapClear BaseChapClear;

    public bool isClear = false;

    private void Update()
    {
        // Debug.Log("조건 체크중");
        if(!isClear)
        {
            // CheckClearCondition();
        }
    }
    private void CheckClearCondition()
    {
        if(chairManager == null &&  itemPlace == null)
        {
            Debug.LogError("아무런 조건이 없습니다.");
            return;
        }

        bool chairclear = (chairManager == null || chairManager.CheckChairs());
        bool itemClear = (itemPlace == null || itemPlace.HasItem);

        if(chairclear && itemClear)
        {
            Debug.Log("조건 달성");
            BaseChapClear.ClearEvent();
            isClear = true;
        }
    }

    //public bool Test()
    //{
    //    return itemPlace.PlacedItem.GetItemType() == ItemType.OpenBook ? true : false;
    //}
}
