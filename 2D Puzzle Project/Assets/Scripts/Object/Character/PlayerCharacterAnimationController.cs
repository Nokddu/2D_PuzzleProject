using UnityEngine;
using Backend.Data;

namespace Backend.Object.Character
{
    public class PlayerCharacterAnimationController : MonoBehaviour
    {
        [Header("Data Settings")]
        [SerializeField] private AnimationClipData[] data;
    }
}
