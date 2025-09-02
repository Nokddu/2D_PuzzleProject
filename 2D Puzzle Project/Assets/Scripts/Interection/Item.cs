using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemtype;
    
    // ��ȣ�ۿ�� ȣ�� �Լ�
    public ItemType GetItemType()
    {
        return itemtype;
    }
    //�÷��̾ �������� ���� �� ȣ�߿��
    public void OnPick()
    {
        gameObject.SetActive(false);
    }
    //�÷��̾ �������� ���־�
    public void OnPlace(Vector3 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);

    }
    public void ResetPosition()
    {

    }
}
