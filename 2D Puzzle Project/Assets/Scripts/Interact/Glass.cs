using Backend.Object;
using Backend.Object.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerCharacterMovementController>();

        if(player != null )
        {
            var controller = player.GetComponent<ObjectMovementController>();

            controller.ForceStop();

            controller.Move(-player.Forward);

            GameManager.Ins.HP--;
        }
    }
}
