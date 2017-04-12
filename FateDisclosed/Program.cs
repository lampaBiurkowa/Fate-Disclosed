using System;

namespace FateDisclosed
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Windows.Forms.MessageBox.Show("Proszę uruchomić za pomocą FateDisclosedLauncher", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }
            else
            {
                AppCore app = new AppCore(new SFML.System.Vector2i(Int32.Parse(args[0]), Int32.Parse(args[1])));
                app.Start();
                app.Run();
            }
        }
    }
}
