namespace Render;
using SDL2;
public class GLContext
{
    
    public nint _sdlGLContextRef = -1;
    public GLContext(Window window) {
        _sdlGLContextRef = SDL.SDL_GL_CreateContext(window._sdlWindowRef);
    }
    
}
