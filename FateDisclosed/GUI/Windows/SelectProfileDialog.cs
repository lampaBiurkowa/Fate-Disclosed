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
    class SelectProfileDialog : DialogWindow
    {
        public SelectProfileDialog(AbstractScreen parentScreen) : base(parentScreen)
        {
            label = "Wybierz profil";
        }
    }
}
