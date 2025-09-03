using System;

namespace Backend.Object.Character
{
    [Flags]
    public enum PlayerCharacterAnimationState
    {
        None = 0,
        
        // Animation Direction State
        Up    = 1 << 0,
        Down  = 1 << 1,
        Left  = 1 << 2,
        Right = 1 << 3,

        // Animation Sprite State
        Idle  = 1 << 4,
        Death = 1 << 5,
        Hurt  = 1 << 6,
        Jump  = 1 << 7,
        Walk  = 1 << 8,
    }
}
