namespace EnvironmentSystem.Models
{
    using System;

    [Flags]
    public enum CollisionGroup
    {
        Nothing = 0,
        Snowflake = 1,
        MeltedSnow = 2,
        Ground = 3,
        Snow = 4,
        Explosion = 5,
        FallingStar = 6
    }
}
