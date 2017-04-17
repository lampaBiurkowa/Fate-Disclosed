using System;

namespace FateDisclosed.Screens
{
    public class ScreenManager
    {
        AbstractScreen currentScreen;
        SFML.System.Clock clock;

        public ScreenManager()
        {
            clock = new SFML.System.Clock();
        }

        public void SetScreen(AbstractScreen screen)
        {
            currentScreen = screen;
            StartScreen();
        }

        public void StartScreen()
        {
            try
            {
                currentScreen.Start();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Screen does not exist! " + e.Message);
            }
        }

        public void Update()
        {
            try
            {
                currentScreen.Update(clock.ElapsedTime.AsSeconds());
                clock.Restart();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Screen does not exist! " + e.Message);
            }
        }

        public void Draw()
        {
            try
            {
                currentScreen.Draw();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Screen does not exist! " + e.Message);
            }
        }
    }
}
