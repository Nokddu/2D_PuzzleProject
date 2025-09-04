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
        Destroy(gameObject);
    }
    //�÷��̾ �������� ���־�
    public void OnPlace(Vector3 pos)
    {
        Instantiate(gameObject).transform.position = pos;
    }
    public void ResetPosition()
    {

    }
}
