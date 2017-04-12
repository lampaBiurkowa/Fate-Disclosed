namespace FateDisclosed.Screens
{
    public abstract class AbstractScreen
    {
        public AppCore app { get; private set; }

        public AbstractScreen(AppCore app)
        {
            this.app = app;
        }

        public abstract void Start();
        public abstract void Update(float deltaTime);
        public abstract void Draw();
    }
}
