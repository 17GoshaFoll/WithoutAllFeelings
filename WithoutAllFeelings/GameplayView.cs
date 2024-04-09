using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WithoutAllFeelings;

public interface IGameplayView
{
    event EventHandler CycleFinished;
    event EventHandler<ControlsEventArgs> PlayerMoved;

    void LoadGameCycleParameters(Vector2 pos);
    void Run();
}

public class ControlsEventArgs : EventArgs
{
    public Model.Direction Direction { get; set; }
}