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
    public class MouseInput
    {
        bool oldStatePressed;
        bool newStatePressed;

        public bool MousePressed(Mouse.Button button)
        {
            newStatePressed = Mouse.IsButtonPressed(button);

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

        public bool MouseReleased(Mouse.Button button)
        {
            newStateReleased = Mouse.IsButtonPressed(button);

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
