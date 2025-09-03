using UnityEngine;

namespace Backend.Object
{
    public interface IMoveable
    {
        void Move(Vector3 direction, float scale, int length);
    }
}