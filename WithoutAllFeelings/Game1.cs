using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WithoutAllFeelings;

public class Game1 : Game, IGameplayView
{
    private readonly GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D background;
    private Vector2 playerPos = Vector2.Zero;
    private Texture2D playerImage;

    public event EventHandler CycleFinished = delegate { };
    public event EventHandler<ControlsEventArgs> PlayerMoved = delegate { };

    public void LoadGameCycleParameters(Vector2 pos)
    {
        playerPos = pos;
    }

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = 1920;
        graphics.PreferredBackBufferHeight = 1080;
        graphics.ApplyChanges();
        IsMouseVisible = true;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        background = Content.Load<Texture2D>("Background");
        playerImage = Content.Load<Texture2D>("WhiteBox");
    }

    protected override void Update(GameTime gameTime)
    {
        var keys = Keyboard.GetState().GetPressedKeys();
        if (keys.Length > 0)
        {
            var k = keys[0];
            switch (k)
            {
                case Keys.W:
                    {
                        PlayerMoved.Invoke(
                            this,
                            new ControlsEventArgs { Direction = Model.Direction.Up }
                        );
                        break;
                    }
                case Keys.S:
                    {
                        PlayerMoved.Invoke(
                            this,
                            new ControlsEventArgs { Direction = Model.Direction.Down }
                        );
                        break;
                    }
                case Keys.D:
                    {
                        PlayerMoved.Invoke(
                            this,
                            new ControlsEventArgs { Direction = Model.Direction.Right }
                        );
                        break;
                    }
                case Keys.A:
                    {
                        PlayerMoved.Invoke(
                            this,
                            new ControlsEventArgs { Direction = Model.Direction.Left }
                        );
                        break;
                    }
                case Keys.Escape:
                    {
                        Exit();
                        break;
                    }
            }
        }

        base.Update(gameTime);
        CycleFinished.Invoke(this, new EventArgs());
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(playerImage, playerPos, Color.White);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}