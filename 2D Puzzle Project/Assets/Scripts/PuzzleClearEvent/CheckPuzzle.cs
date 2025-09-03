using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzzle : MonoBehaviour
{
    [SerializeField] private ChairManager chairManager;
    [SerializeField] private ItemPlaceSpot itemPlace;
    [SerializeField] private Foothold foothold;

    [SerializeField] private BaseChapClear BaseChapClear;

    public bool isClear = false;

    private void Update()
    {
        Debug.Log("���� üũ��");
        if(!isClear)
        {
            CheckClearCondition();
        }
    }
    private void CheckClearCondition()
    {
        if(chairManager == null &&  itemPlace == null && foothold == null)
        {
            Debug.LogError("�ƹ��� ������ �����ϴ�.");
            return;
        }

        bool chairclear = (chairManager == null || chairManager.CheckChairs());
        bool itemClear = (itemPlace == null || itemPlace.HasItem);
        bool footholdClear = (foothold == null || foothold.IsOn);

        if(chairclear && itemClear && footholdClear)
        {
            Debug.Log("���� �޼�");
            BaseChapClear.ClearEvent();
            isClear = true;
        }
    }
}
