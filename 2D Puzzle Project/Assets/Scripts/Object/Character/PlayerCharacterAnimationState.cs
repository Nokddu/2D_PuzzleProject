using System;

namespace Backend.Object.Character
{
    [Flags]
    public enum PlayerCharacterAnimationState
    {
        // Animation Direction State
        Up    = 0,
        Down  = 1 << 0,
        Left  = 1 << 1,
        Right = 1 << 2,

        // Animation Sprite State
        Idle  = 1 << 3,
        Death = 1 << 4,
        Hurt  = 1 << 5,
        Jump  = 1 << 6,
        Walk  = 1 << 7,
    }
}
