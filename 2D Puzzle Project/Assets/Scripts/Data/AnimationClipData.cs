using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Animation Clip Data", menuName = "Scriptable Object/Data/Animation Clip")]
    public class AnimationClipData : ScriptableObject
    {
        [SerializeField] private AnimationClip up;
        [SerializeField] private AnimationClip down;
        [SerializeField] private AnimationClip right;

        public AnimationClip Up => up;

        public AnimationClip Down => down;

        public AnimationClip Right => right;
    }
}
