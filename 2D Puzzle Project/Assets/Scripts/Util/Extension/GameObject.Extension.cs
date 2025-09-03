using UnityEngine;

namespace Backend.Util.Extension
{
    public static class GameObjectExtension
    {
        public static bool HasLayer(this GameObject gameObject, LayerMask mask)
        {
            return (mask.value & (1 << gameObject.layer)) != 0;
        }
    }
}
