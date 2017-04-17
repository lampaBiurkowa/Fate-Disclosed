/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using FateDisclosed.Screens;

namespace FateDisclosed.GUI.Windows
{
    class OptionsDialog : DialogWindow
    {
        public OptionsDialog(AbstractScreen parentScreen) : base(parentScreen)
        {
            label = "Opcje";
        }
    }
}
