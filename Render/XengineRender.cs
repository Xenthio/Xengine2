namespace Render;

public class Renderer
{
    public Window RenderWindow;
    public GLContext RenderContext;
    public void InitialiseWindow(string windowName) {
        RenderWindow = new Window("Xengine", 0,0, 1280, 720, WindowFlags.OpenGL);
        RenderWindow.Title = windowName;
    }
    public void InitialiseRenderContext() {
        RenderContext = new GLContext(RenderWindow);
    }
}
