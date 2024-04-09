using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WithoutAllFeelings;

public class GameplayPresenter
{
    private IGameplayView gameplayView = null;
    private Model gameplayModel = null;

    public GameplayPresenter(
        IGameplayView gameplayView,
        Model gameplayModel
    )
    {
        this.gameplayView = gameplayView;
        this.gameplayModel = gameplayModel;

        this.gameplayView.CycleFinished += ViewModelUpdate;
        this.gameplayView.PlayerMoved += ViewModelMovePlayer;
        this.gameplayModel.Updated += ModelViewUpdate;

    }

    private void ViewModelMovePlayer(object sender, ControlsEventArgs e)
    {
        gameplayModel.MovePlayer(e.Direction);
    }

    private void ModelViewUpdate(object sender, GameplayEventArgs e)
    {
        gameplayView.LoadGameCycleParameters(e.PlayerPos);
    }

    private void ViewModelUpdate(object sender, EventArgs e)
    {
        gameplayModel.Update();
    }
    
    public void LaunchGame()
    {
        gameplayView.Run();
    }
}