using GameBase.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameBase
{
    public class Input
    {
        //Get the User Input
        public InputStatus GetInput()
        {
            var status = new InputStatus();
            if (shareModel.sleepgame==true)
            {
                Thread.Sleep(3000);
                shareModel.sleepgame = false;
            }
            if (shareModel.sleepgame == false)
            {

                if (Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.W))
                    status.Direction = Direction.UP;
                if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.S))
                    status.Direction = Direction.DOWN;
                if (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.A))
                    status.Direction = Direction.LEFT;
                if (Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.D))
                    status.Direction = Direction.RIGHT;
            }
            return status;
        }
    }

    public class InputStatus
    {
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
}
