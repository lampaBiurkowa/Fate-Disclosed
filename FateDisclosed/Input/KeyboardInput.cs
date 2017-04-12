/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
***/
using SFML.Window;

namespace FateDisclosed.Input
{
    public class KeyboardInput
    {
        bool oldStatePressed;
        bool newStatePressed;

        public bool KeyPressed(Keyboard.Key key)
        {
            newStatePressed = Keyboard.IsKeyPressed(key);

            if (oldStatePressed == false && newStatePressed == true)
            {
                oldStatePressed = newStatePressed;
                return true;
            }
            oldStatePressed = newStatePressed;
            return false;
        }

        bool oldStateReleased;
        bool newStateReleased;

        public bool KeyReleased(Keyboard.Key key)
        {
            newStateReleased = Keyboard.IsKeyPressed(key);

            if (oldStateReleased == true && newStateReleased == false)
            {
                oldStateReleased = newStateReleased;
                return true;
            }
            oldStateReleased = newStateReleased;
            return false;
        }
    }
}
