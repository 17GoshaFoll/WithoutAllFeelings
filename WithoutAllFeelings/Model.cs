using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WithoutAllFeelings;

public interface Model
{
    event EventHandler<GameplayEventArgs> Updated;

    void Update();
    void MovePlayer(Direction dir);

    public enum Direction : byte
    {
        Up,
        Down,
        Right,
        Left
    }
}

public class GameplayEventArgs : EventArgs
{
    public Vector2 PlayerPos { get; set; }
}