using UnityEngine;
using Backend.Data;
using System;
using Backend.Util.Animation;

namespace Backend.Object.Character
{
    public class PlayerCharacterAnimationController : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private AnimationClipData death;
        [SerializeField] private AnimationClipData hurt;
        [SerializeField] private AnimationClipData idle;
        [SerializeField] private AnimationClipData jump;
        [SerializeField] private AnimationClipData walk;
        
        private SpriteLegacyAnimation _animation;

        private void Awake()
        {
            _animation = GetComponentInChildren<SpriteLegacyAnimation>();
        }

        public void Play(PlayerCharacterAnimationState state, bool isLooping = false)
        {
            switch (state)
            {
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Death):
                    Play(death, state, isLooping);
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Hurt):
                    Play(hurt, state, isLooping);
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Idle):
                    Play(idle, state, isLooping);
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Jump):
                    Play(jump, state, isLooping);
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Walk):
                    Play(walk, state, isLooping);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Play(AnimationClipData clip, PlayerCharacterAnimationState state, bool isLooping)
        {
            SpriteData data;
            var isFlip = false;

            switch (state)
            {
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Up):
                    data = clip.Up;
                    isFlip = false;
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Down):
                    data = clip.Down;
                    isFlip = false;
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Left):
                    data = clip.Right;
                    isFlip = true;
                    break;
                case var _ when state.HasFlag(PlayerCharacterAnimationState.Right):
                    data = clip.Right;
                    isFlip = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _animation.Renderer.flipX = isFlip;

            _animation.Play(data, isLooping);
        }
    }
}
