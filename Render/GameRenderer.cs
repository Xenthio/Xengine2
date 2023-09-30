using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Input;

namespace Render;

public class GameRenderer
{
    public IInputContext Input;
    public IWindow GameWindow;
    public WindowOptions Options = WindowOptions.Default with
    {
        Size = new Vector2D<int>(1280, 720),
        Title = "Xengine"
    };
    public void InitialiseWindow(string windowName) 
    {
        GameWindow = Window.Create(Options);
        Options.Title = windowName;
    }
    public void InitialiseInput()
    {
        Input = GameWindow.CreateInput();
    }

    public void RunWindow() {
        GameWindow.Run();
    }
}
