using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Backend.Util;
using Backend.Util.Input;
using Backend.Util.Extension;

namespace Backend.Object.Character
{
    [RequireComponent(typeof(Rigidbody2D), typeof(ObjectMovementController))]
    public class PlayerCharacterMovementController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float height = 0.8f;
        
        [Header("Collision Settings")]
        [SerializeField] private LayerMask mask;

        [Header("Debug Information")]
        [SerializeField] private Vector3 forward = Vector3.right;
        [SerializeField] private bool isMoveable;
        [SerializeField] private bool isJumpable;
        [SerializeField] private bool isPushable;
        [SerializeField] private bool isMoving;
        [SerializeField] private bool isJumping;
        [SerializeField] private bool isPressed;

        private PlayerCharacterAnimationController _animation;
        private ObjectMovementController _controller;

        private ObjectControls _controls;

        private PlayerCharacterAnimationState _state = PlayerCharacterAnimationState.Right;
        private RaycastHit2D[] _hits;
        private Vector3 _direction;
        private int _count;

        private void Awake()
        {
            _animation = GetComponent<PlayerCharacterAnimationController>();
            _controller = GetComponent<ObjectMovementController>();

            _controls = new ObjectControls();

            _hits = new RaycastHit2D[2];
        }

        private void OnEnable()
        {
            _controls.Player.Enable();
            _controls.Player.MoveToUpDirection.performed += LookToUpDirection;
            _controls.Player.MoveToDownDirection.performed += LookToDownDirection;
            _controls.Player.MoveToLeftDirection.performed += LookToLeftDirection;
            _controls.Player.MoveToRightDirection.performed += LookToRightDirection;
            _controls.Player.MoveToUpDirection.performed += MoveToUpDirection;
            _controls.Player.MoveToDownDirection.performed += MoveToDownDirection;
            _controls.Player.MoveToLeftDirection.performed += MoveToLeftDirection;
            _controls.Player.MoveToRightDirection.performed += MoveToRightDirection;
            _controls.Player.MoveToUpDirection.canceled += Stop;
            _controls.Player.MoveToDownDirection.canceled += Stop;
            _controls.Player.MoveToLeftDirection.canceled += Stop;
            _controls.Player.MoveToRightDirection.canceled += Stop;
            _controls.Player.Jump.performed += Jump;
        }

        private void Start()
        {
            _animation.Play(_state | PlayerCharacterAnimationState.Idle, true);
        }

        private void Update()
        {
            Detect();

            isPressed = IsPressed();
            if (isPressed)
            {
                _animation.Play(_state | PlayerCharacterAnimationState.Walk, true);
            }
            else if (_controller.IsMoving == false)
            {
                _animation.Play(_state | PlayerCharacterAnimationState.Idle, true);
            }

            if (isPressed && isPushable)
            {
                IMoveable moveable = _hits[0].collider.GetComponent<ObjectMovementController>();

                moveable.Move(forward, 5f);
            }

            if (isMoveable && _direction != Vector3.zero && _controller.IsMoving == false)
            {
                _controller.Move(_direction, 5f);
            }
        }

        private void OnDisable()
        {
            _controls.Player.MoveToUpDirection.performed -= LookToUpDirection;
            _controls.Player.MoveToDownDirection.performed -= LookToDownDirection;
            _controls.Player.MoveToLeftDirection.performed -= LookToLeftDirection;
            _controls.Player.MoveToRightDirection.performed -= LookToRightDirection;
            _controls.Player.MoveToUpDirection.performed -= MoveToUpDirection;
            _controls.Player.MoveToDownDirection.performed -= MoveToDownDirection;
            _controls.Player.MoveToLeftDirection.performed -= MoveToLeftDirection;
            _controls.Player.MoveToRightDirection.performed -= MoveToRightDirection;
            _controls.Player.MoveToUpDirection.canceled -= Stop;
            _controls.Player.MoveToDownDirection.canceled -= Stop;
            _controls.Player.MoveToLeftDirection.canceled -= Stop;
            _controls.Player.MoveToRightDirection.canceled -= Stop;
            _controls.Player.Jump.performed -= Jump;
            _controls.Player.Disable();
        }

        private void LookToUpDirection(InputAction.CallbackContext context)
        {
            _state = PlayerCharacterAnimationState.Up;
            
            forward = Vector3.up;
        }
        
        private void LookToDownDirection(InputAction.CallbackContext context)
        {
            _state = PlayerCharacterAnimationState.Down;
            
            forward = Vector3.down;
        }
        
        private void LookToLeftDirection(InputAction.CallbackContext context)
        {
            _state = PlayerCharacterAnimationState.Left;
            
            forward = Vector3.left;
        }
        
        private void LookToRightDirection(InputAction.CallbackContext context)
        {
            _state = PlayerCharacterAnimationState.Right;
            
            forward = Vector3.right;
        }

        private void MoveToUpDirection(InputAction.CallbackContext context)
        {
            _direction = Vector3.up;
        }
        
        private void MoveToDownDirection(InputAction.CallbackContext context)
        {
            _direction = Vector3.down;
        }
        
        private void MoveToLeftDirection(InputAction.CallbackContext context)
        {
            _direction = Vector3.left;
        }
        
        private void MoveToRightDirection(InputAction.CallbackContext context)
        {
            _direction = Vector3.right;
        }

        private void Stop(InputAction.CallbackContext context)
        {
            _direction = Vector3.zero;
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (isJumpable == false || _controller.IsMoving)
            {
                return;
            }
            
            _animation.Play(_state | PlayerCharacterAnimationState.Jump);
            
            _controller.Move(forward, 2.5f, _count);
        }

        private void Detect()
        {
            var position = new Vector2(transform.position.x, transform.position.y);
            var direction = new Vector2(forward.x, forward.y);
            var length = Physics2D.RaycastNonAlloc(position, direction, _hits, 2f, mask);

            switch (length)
            {
                case 0:
                    isMoveable = true;
                    isJumpable = true;
                    isPushable = false;
                    _count = 2;
                    break;
                case 1 when _hits[0].distance < 1f:
                    var layer = _hits[0].collider.gameObject.layer;
                    isMoveable = false;
                    isJumpable = true;
                    isPushable = layer == Layer.Pushable;
                    _count = 2;
                    break;
                case 1 when _hits[0].distance > 1f:
                    isMoveable = true;
                    isJumpable = true;
                    isPushable = false;
                    _count = 1;
                    break;
                case 2:
                    isMoveable = false;
                    isJumpable = false;
                    isPushable = false;
                    break;

            }

#if UNITY_EDITOR

            Debug.DrawLine(transform.position, transform.position + forward * 2f, Color.red);

            if (length > 0)
            {
                Debug.DrawLine(transform.position, _hits[0].point, Color.green);
            }

#endif
        }

        private bool IsPressed()
        {
            var a = _controls.Player.MoveToUpDirection.IsPressed();
            var b = _controls.Player.MoveToDownDirection.IsPressed();
            var c = _controls.Player.MoveToLeftDirection.IsPressed();
            var d = _controls.Player.MoveToRightDirection.IsPressed();
            
            return a || b || c || d;
        }

        public Vector3 Forward => forward;
    }
}
