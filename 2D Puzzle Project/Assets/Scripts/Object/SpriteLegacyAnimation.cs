using System.Collections;
using Backend.Data;
using UnityEngine;

namespace Backend.Util.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteLegacyAnimation : MonoBehaviour
    {
        [Header("Debug Information")]
        [SerializeField] private string animationName;

        private bool _isPlaying;
        
        private void Awake()
        {
            Renderer = GetComponent<SpriteRenderer>();
        }

        public void Play(SpriteData data, bool isLooping)
        {
            if (_isPlaying && animationName == data.name)
            {
                return;
            }

            animationName = data.name;

            StopAllCoroutines();
            StartCoroutine(Playing(data, isLooping));
        }

        private IEnumerator Playing(SpriteData data, bool isLooping)
        {
            _isPlaying = true;

            var length = data.Length;
            var duration = data.Duration;
            var delay = new WaitForSeconds(duration / length);

            for (var index = 0; index < length; index = isLooping ? (index + 1) % length : index + 1)
            {
                Renderer.sprite = data[index];

                yield return delay;
            }

            _isPlaying = false;
        }

        public SpriteRenderer Renderer { get; private set; }
    }
}