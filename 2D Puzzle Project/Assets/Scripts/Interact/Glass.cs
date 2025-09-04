using Backend.Object;
using Backend.Object.Character;
using UnityEngine;

public class Glass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCharacterMovementController>(out var component))
        {
            var controller = collision.GetComponent<ObjectMovementController>();
            controller.Move(-component.Forward, 5f);

            GameManager.Ins.HP--;
            if (GameManager.Ins.HP <= 0)
            {
                GameManager.Ins.GameOver();
            }
        }
    }
}
