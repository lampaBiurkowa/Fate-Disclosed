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
        AssetsManager menuAssets;
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

        public MainMenuScreen(AppCore app, AssetsManager manager) : base(app)
        {
            menuAssets = manager;
        }

        public override void Draw()
        {
            app.win.Draw(menuLayer1);
            app.win.Draw(menuLayer2);

            startGame.Draw();
            loadGame.Draw();
            selectProfile.Draw();
            options.Draw();
            quitGame.Draw();

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
            menuLayer1 = new Sprite(menuAssets.GetTexture("menu layer1"));
            menuLayer2 = new Sprite(menuAssets.GetTexture("menu layer2"));
            //Buttons
            startGame = new GUI.Controls.Button(app.win, menuAssets.GetTexture("button"), "Start", menuAssets.GetFont("arial"));
            loadGame = new GUI.Controls.Button(app.win, menuAssets.GetTexture("button"), "Load game", menuAssets.GetFont("arial"));
            selectProfile = new GUI.Controls.Button(app.win, menuAssets.GetTexture("button"), "Select profile", menuAssets.GetFont("arial"));
            options = new GUI.Controls.Button(app.win, menuAssets.GetTexture("button"), "Options", menuAssets.GetFont("arial"));
            quitGame = new GUI.Controls.Button(app.win, menuAssets.GetTexture("button"), "Quit", menuAssets.GetFont("arial"));

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
