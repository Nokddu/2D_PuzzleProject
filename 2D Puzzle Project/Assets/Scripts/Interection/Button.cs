using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] private float ButtonCheckRadius = 3f;
    [SerializeField] protected ChairManager chair;



    public virtual void Interact()
    {
        
    }

    

    public void TryCheck()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, ButtonCheckRadius);

        foreach (var col in collider)
        {
            
        }
    }
}
