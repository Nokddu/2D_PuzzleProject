using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Sprite Data", menuName = "Scriptable Object/Data/Sprite")]
    public class SpriteData : ScriptableObject
    {
        [SerializeField] private Sprite[] images;
        [Space(4f)]
        [SerializeField] private float duration;

        public Sprite this[int index] => images[index];

        public float Duration => duration;

        public int Length => images.Length;
    }
}