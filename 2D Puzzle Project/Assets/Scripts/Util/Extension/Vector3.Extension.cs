using UnityEngine;

namespace Backend.Util.Extension
{
    public static class Vector3Extension
    {
        public static Vector3Int ToInt(this Vector3 value)
        {
            return new Vector3Int((int)value.x, (int)value.y, (int)value.z);
        }
    }
}
