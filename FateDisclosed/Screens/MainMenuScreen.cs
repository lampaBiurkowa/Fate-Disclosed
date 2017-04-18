/***
 * *********
 * This source uses SFML (Simple and Fast Multimedia Library)
 * which is released under the zlib/png license.
 * Copyright (c) Laurent Gomila
 * *********
 ***/
using FateDisclosed.GUI.Windows;
using SFML.Graphics;

namespace FateDisclosed.Screens
{
    class MainMenuScreen : AbstractScreen
    {
        Sprite menuLayer1;
        Sprite menuLayer2;

        GUI.Controls.Button startGame;
        GUI.Controls.Button loadGame;
        GUI.Controls.Button selectProfile;
        GUI.Controls.Button options;
        GUI.Controls.Button quitGame;

        ExitDialog windowExit;
        SelectProfileDialog selectProfileDialog;
        OptionsDialog optionsDialog;

        public MainMenuScreen(AppCore app) : base(app)
        {
            
        }

        public override void Draw()
        {
            app.win.Draw(menuLayer1);
            app.win.Draw(menuLayer2);

            app.win.Draw(startGame);
            app.win.Draw(loadGame);
            app.win.Draw(selectProfile);
            app.win.Draw(options);
            app.win.Draw(quitGame);

            windowExit.DrawOnWindow();
            app.win.Draw(windowExit);
            selectProfileDialog.DrawOnWindow();
            app.win.Draw(selectProfileDialog);
            optionsDialog.DrawOnWindow();
            app.win.Draw(optionsDialog);
        }

        public override void Start()
        {
            app.view.Size = new SFML.System.Vector2f(app.virtualResolution.X, app.virtualResolution.Y);
            app.view.Center = new SFML.System.Vector2f(app.virtualResolution.X / 2, app.virtualResolution.Y / 2);
            
            //Menu layers
            menuLayer1 = new Sprite(AssetsManager.GetTexture("menu layer1"));
            menuLayer2 = new Sprite(AssetsManager.GetTexture("menu layer2"));
            //Buttons
            startGame = new GUI.Controls.Button(app.win, AssetsManager.GetTexture("button"), "Start", AssetsManager.GetFont("caprkfont"));
            loadGame = new GUI.Controls.Button(app.win, AssetsManager.GetTexture("button"), "Load game", AssetsManager.GetFont("caprkfont"));
            selectProfile = new GUI.Controls.Button(app.win, AssetsManager.GetTexture("button"), "Select profile", AssetsManager.GetFont("caprkfont"));
            options = new GUI.Controls.Button(app.win, AssetsManager.GetTexture("button"), "Options", AssetsManager.GetFont("caprkfont"));
            quitGame = new GUI.Controls.Button(app.win, AssetsManager.GetTexture("button"), "Quit", AssetsManager.GetFont("caprkfont"));

            startGame.TextHeightFix = 15;
            loadGame.TextHeightFix = 15;
            selectProfile.TextHeightFix = 15;
            options.TextHeightFix = 15;
            quitGame.TextHeightFix = 15;

            startGame.Position = new SFML.System.Vector2f(app.virtualResolution.X - 400, 200);
            loadGame.Position = new SFML.System.Vector2f(app.virtualResolution.X - 400, 320);
            selectProfile.Position = new SFML.System.Vector2f(app.virtualResolution.X - 400, 440);
            options.Position = new SFML.System.Vector2f(app.virtualResolution.X - 400, 560);
            quitGame.Position = new SFML.System.Vector2f(app.virtualResolution.X - 400, 680);

            windowExit = new ExitDialog(this);
            selectProfileDialog = new SelectProfileDialog(this);
            optionsDialog = new OptionsDialog(this);
        }

        public override void Update(float deltaTime)
        {
            startGame.Update();
            loadGame.Update();
            selectProfile.Update();
            options.Update();
            quitGame.Update();

            if(quitGame.Pressed())
            {
                windowExit.Show();
            }
            if(selectProfile.Pressed())
            {
                selectProfileDialog.Show();
            }
            if(options.Pressed())
            {
                optionsDialog.Show();
            }

            windowExit.Update(deltaTime);
            selectProfileDialog.Update(deltaTime);
            optionsDialog.Update(deltaTime);
        }
    }
}
