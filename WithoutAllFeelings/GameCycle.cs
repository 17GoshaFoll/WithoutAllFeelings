using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WithoutAllFeelings;

public class GameCycle : Model
{
    public event EventHandler<GameplayEventArgs> Updated = delegate { };
    private int horizontalRightSpeed = 10;
    private int horizontalLeftSpeed = 10;

    private Vector2 pos = new(300, 300);

    public void Update()
    {
        Updated.Invoke(this, new GameplayEventArgs { PlayerPos = pos });
    }

    public void MovePlayer(Model.Direction dir)
    {
        switch (dir)
        {
            case Model.Direction.Up:
                {
                    GetJump();
                    // //ChangeVerticalForwardSpeed(1);
                    // pos += new Vector2(0, -5);

                    break;
                }
            case Model.Direction.Down:
                {
                    break;
                }
            case Model.Direction.Right:
                {
                    //ChangeHorizontalRightSpeed(1);
                    pos += new Vector2(horizontalRightSpeed, 0);
                    break;
                }
            case Model.Direction.Left:
                {
                    //ChangeHorizontalLeftSpeed(1);
                    pos += new Vector2(-horizontalLeftSpeed, 0);
                    break;
                }
        }
    }

    private void ChangeHorizontalLeftSpeed(int speedDeference)
    {
        horizontalLeftSpeed += speedDeference;
        horizontalRightSpeed = 0;
    }

    private void ChangeHorizontalRightSpeed(int speedDeference)
    {
        horizontalRightSpeed += speedDeference;
        horizontalLeftSpeed = 0;
    }

    private Vector2 GetJump()
    {
        var timeJump = 0;
        while (timeJump == 10)
        {
            timeJump += 1;
            if (timeJump < 7)
            {
                pos += new Vector2(0, -1);
            }
            else
                pos += new Vector2(0, 1);
        }

        return pos;
    }
}

// private void ChangeVerticalForwardSpeed(int speedDeference)
// {
//     verticalForwardSpeed += speedDeference;
//     verticalBackwardSpeed = 0;
// }

// private void ChangeVerticalBackwardSpeed(int speedDeference)
// {
//     verticalBackwardSpeed += speedDeference;
//     verticalForwardSpeed = 0;
// }