using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using Backend.Util.Extension;

namespace Backend.Object
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObjectMovementController : MonoBehaviour, IMoveable
    {
        [Header("Tilemap Settings")]
        [SerializeField] private Tilemap tilemap;

        [Header("Movement Settings")]
        [SerializeField] private float speed = 5f;

        [Header("Debug Information")]
        [SerializeField] private bool isMoving;

        private BoxCollider2D _collider;

        private Vector3Int _position;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();

            // Initialize the position of the current cell containing the player character on the tilemap.
            _position = GetCellPosition(transform.position);

            transform.position = tilemap.GetCellCenterWorld(_position);
        }

        public void Move(Vector3 direction, float scale, int length = 1)
        {
            var distance = direction.ToInt() * length;

            StopAllCoroutines();
            StartCoroutine(Moving(distance, scale));
            
        }

        private IEnumerator Moving(Vector3Int distance, float scale)
        {
            _collider.enabled = false;
            isMoving = true;

            var position = _position + distance;
            var start = transform.position;
            var end = GetWorldPosition(position);
            
            for (var time = 0f; time < 1f; time += Time.deltaTime * scale)
            {
                transform.position = Vector3.Lerp(start, end, time);
                if(time < 0.005f)SoundManager.Ins.PlaySound("Walk");
                yield return null;
            }

            transform.position = end;

            _position = position;

            _collider.enabled = true;

            yield return new WaitForSeconds(0.02f);

            isMoving = false;
        }

        private Vector3Int GetCellPosition(Vector3 position)
        {
            return tilemap.WorldToCell(position);
        }

        public Vector3 GetWorldPosition(Vector3Int position)
        {
            return tilemap.CellToWorld(position) + tilemap.cellSize / 2;
        }

        public bool IsMoving => isMoving;
    }
}
