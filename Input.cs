/*============================================================================
  Copyright (C) 2016 akitsu sanae
  https://github.com/akitsu-sanae/monaka
  Distributed under the Boost Software License, Version 1.0. (See accompanying
  file LICENSE or copy at http://www.boost.org/LICENSE_1_0.txt)
============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monaka
{
    static class Input
    {
        enum InputType
        {
            Keyboard,
            JoyStick
        }
        static InputType type = InputType.Keyboard;
        public static void Initialize()
        {
            if (asd.Engine.JoystickContainer.GetIsPresentAt(0))
                type = InputType.JoyStick;
            else
                type = InputType.Keyboard;
        }

        public enum Button
        {
            Up,
            Down,
            Left,
            Right,

            Button1,
            Button2,
            Button3
        }

        public static bool isPushed(Button button)
        {
            if (type == InputType.Keyboard)
            {
                var keyboard = asd.Engine.Keyboard;
                switch (button)
                {
                    case Button.Up:
                        return keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold;
                    case Button.Down:
                        return keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold;
                    case Button.Left:
                        return keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold;
                    case Button.Right:
                        return keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold;
                    case Button.Button1:
                        return keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push;
                    case Button.Button2:
                        return keyboard.GetKeyState(asd.Keys.X) == asd.KeyState.Push;
                    case Button.Button3:
                        return keyboard.GetKeyState(asd.Keys.C) == asd.KeyState.Push;
                }
            }
            else if (type == InputType.JoyStick)
            {
                var joystick = asd.Engine.JoystickContainer.GetJoystickAt(0);
                switch (button)
                {
                    case Button.Up:
                        return joystick.GetAxisState(1) < -0.5;
                    case Button.Down:
                        return joystick.GetAxisState(1) > 0.5;
                    case Button.Left:
                        return joystick.GetAxisState(0) < -0.5;
                    case Button.Right:
                        return joystick.GetAxisState(0) > 0.5;
                    case Button.Button1:
                        return joystick.GetButtonState(0) == asd.JoystickButtonState.Push;
                    case Button.Button2:
                        return joystick.GetButtonState(1) == asd.JoystickButtonState.Push;
                    case Button.Button3:
                        return joystick.GetButtonState(2) == asd.JoystickButtonState.Push;
                }
            }
            return false;
        }
    }
}
