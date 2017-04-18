using SFML.System;

namespace FateDisclosed.Screens
{
    class SplashScreen : AbstractScreen
    {
        MoviePlayer movie;
        MoviePlayer loadingAnimation;
        Clock time;

        public SplashScreen(AppCore app) : base(app)
        {
        }

        public override void Draw()
        {
            app.win.Draw(movie);
        }

        public override void Start()
        {
            time = new Clock();
            app.view.Size = new Vector2f(1920, 1080);
            app.view.Center = new SFML.System.Vector2f(1920 / 2, 1080 / 2);

            loadingAnimation = new MoviePlayer("res/loading.mp4", this);
            movie = new MoviePlayer("res/splash.mp4", this);
            movie.Play();
        }

        public override void Update(float deltaTime)
        {
            movie.Update();
            if(time.ElapsedTime.AsSeconds() >= 14 || new Input.KeyboardInput().KeyPressed(SFML.Window.Keyboard.Key.Escape))
            {
                loadingAnimation.Play();
                loadingAnimation.Update();
                movie.Stop();
                app.manager.SetScreen(new LoadingScreen(app, loadingAnimation));
            }
        }
    }
}
