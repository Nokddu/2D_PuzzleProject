using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] private float ButtonCheckRadius = 3f;
    [SerializeField] private ChairManager chair;

    private void Update()
    {
        
    }

    public void Interact()
    {
        if (chair.CheckChairs())
        {
            Debug.Log("����");
            // �����̴� ���ݼ���

        }
        else
        {
            Debug.Log("����");

            chair.ResetChairs();
        }
    }

    public void TryCheck()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, ButtonCheckRadius);

        foreach (var col in collider)
        {
            
        }
    }
}
