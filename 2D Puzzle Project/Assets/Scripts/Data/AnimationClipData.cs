using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Animation Clip Data", menuName = "Scriptable Object/Data/Animation Clip")]
    public class AnimationClipData : ScriptableObject
    {
        [SerializeField] private SpriteData up;
        [SerializeField] private SpriteData down;
        [SerializeField] private SpriteData right;

        public SpriteData Up => up;

        public SpriteData Down => down;

        public SpriteData Right => right;
    }
}
