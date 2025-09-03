using UnityEngine;
using Backend.Object;
using Backend.Object.Character;

public class Chair : MonoBehaviour
{
    private ObjectMovementController _controller;

    private void Awake()
    {
        _controller = GetComponent<ObjectMovementController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");

        if (other.TryGetComponent<PlayerCharacterMovementController>(out var component))
        {
            _controller.Move(component.Forward, 5f);
        }
    }
}
