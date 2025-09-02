using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Backend.Util.Input;

namespace Backend.Object.Character
{
    [RequireComponent(typeof(Rigidbody2D), typeof(ObjectMovementController))]
    public class PlayerCharacterMovementController : MonoBehaviour
    {
        [Header("Collision Settings")]
        [SerializeField] private LayerMask mask;

        [Header("Debug Information")]
        [SerializeField] private Vector3 forward = Vector3.right;
        [SerializeField] private bool isMoveable;
        [SerializeField] private bool isJumpable;
        [SerializeField] private bool isMoving;

        public Vector3 Forward => forward;

        private ObjectMovementController _controller;

        private ObjectControls _controls;

        private Vector3 _direction;

        private void Awake()
        {
            _controller = GetComponent<ObjectMovementController>();

            _controls = new ObjectControls();
        }

        private void OnEnable()
        {
            _controls.Player.Enable();
            _controls.Player.Move.performed += Look;
            _controls.Player.Move.performed += Move;
            _controls.Player.Move.canceled += Stop;
            _controls.Player.Jump.performed += Jump;
        }

        private void Update()
        {
            var position = transform.position;
            var hits = Physics2D.RaycastAll(position, forward, 2f, mask);

            Array.Sort(hits, (left, right) => left.distance.CompareTo(right.distance));

            isMoveable = hits.Length == 0 || hits[0].distance > 1f;
            isJumpable = hits.Length != 2 && (hits.Length == 1 && hits[0].distance > 1f) == false;

#if UNITY_EDITOR

            Debug.DrawLine(position, position + (forward * 2f), Color.red);

            if (hits.Length > 0)
            {
                Debug.DrawLine(position, hits[0].point, Color.green);
            }

#endif

            if (isMoveable == false || _direction == Vector3.zero || _controller.IsMoving)
            {
                return;
            }

            _controller.Move(_direction);
        }

        private void OnDisable()
        {
            _controls.Player.Move.performed -= Look;
            _controls.Player.Move.performed -= Move;
            _controls.Player.Move.canceled -= Stop;
            _controls.Player.Jump.performed -= Jump;
            _controls.Player.Disable();
        }

        private void Look(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector3>();

            forward = direction == Vector3.zero ? forward : direction;
        }

        private void Move(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector3>();
        }

        private void Stop(InputAction.CallbackContext context)
        {
            _direction = Vector3.zero;
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (isJumpable == false)
            {
                return;
            }

            _controller.Move(forward, 2);
        } 
    }
}
