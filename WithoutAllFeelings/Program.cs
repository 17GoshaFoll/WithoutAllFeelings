using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WithoutAllFeelings;

public static class Program
{
    [STAThread]
    static void Main()
    {
        var g = new GameplayPresenter(
            new Game1(), new GameCycle()
        );
        g.LaunchGame();
    }
}