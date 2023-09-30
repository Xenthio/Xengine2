using SDL2;
namespace Render;

public class Window
{
     
    public nint _sdlWindowRef = -1;
    public nint _sdlRendererRef = -1;
    public Window(string Title, int x = 0, int y = 0, int width = 800, int height = 600, WindowFlags flags = 0) {
        _sdlWindowRef = SDL.SDL_CreateWindow(Title, x, y, width, height, (SDL.SDL_WindowFlags)flags);
    }
    public Window( int width = 800, int height = 600, WindowFlags flags = 0 ) {
        SDL.SDL_CreateWindowAndRenderer(width, height, (SDL.SDL_WindowFlags)flags, out _sdlWindowRef, out _sdlRendererRef);
    }

    public string Title 
    { 
        get { return SDL.SDL_GetWindowTitle(_sdlWindowRef); }
        set { SDL.SDL_SetWindowTitle(_sdlWindowRef, value); }
    }

}


    [Flags]
    public enum WindowFlags : uint
    {
        Shown = 4u,
        Hidden = 8u,

        Borderless = 0x10u,
        Resizable = 0x20u,
        Minimised = 0x40u,
        Maximised = 0x80u,

        InputGrabbed = 0x100u,
        InputFocus = 0x200u,
        MouseFocus = 0x400u,
        MouseCapture = 0x4000u,

        Fullscreen = 1u,
        FullscreenDesktop = 0x1001u,

        Foreign = 0x800u,
        AllowHighDPI = 0x2000u,
        AlwaysOnTop = 0x8000u,
        SkipTaskbar = 0x10000u,

        Utility = 0x20000u,
        Tooltip = 0x40000u,
        PopupMenu = 0x80000u,
        
        OpenGL = 2u,
        Vulkan = 0x10000000u,
        Metal = 0x2000000u
    }