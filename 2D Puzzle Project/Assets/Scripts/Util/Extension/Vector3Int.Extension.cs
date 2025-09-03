using UnityEngine;

namespace Backend.Util.Extension
{
    public static class Vector3IntExtension
    {
        public static Vector3 ToFloat(this Vector3Int value)
        {
            return new Vector3(value.x, value.y, value.z);
        }
    }
}
