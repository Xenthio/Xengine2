using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using System.Drawing;
using Engine;

namespace Render;

public partial class GameRenderer
{
    internal static uint VertexArrayObject;
    internal static uint VertexBufferObject;
    internal static uint ElementBufferObject;
    internal static uint ShaderProgram;
    public IInputContext Input;
    public IWindow GameWindow;
    public static GL GL;
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
    public void InitialiseGL()
    {
        Log.Info("Initalising OpenGL");
        GL = GameWindow.CreateOpenGL();
        VertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(VertexArrayObject);

        VertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(GLEnum.ArrayBuffer, VertexBufferObject);

        ElementBufferObject = GL.GenBuffer();
        GL.BindBuffer(GLEnum.ElementArrayBuffer, ElementBufferObject);

        CompileShaders();

            
    }

    public void CompileShaders() 
    {
        ShaderProgram = GL.CreateProgram();

        uint vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, File.ReadAllText("../../../../content/core/shaders/core.vsh"));
        
        uint fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, File.ReadAllText("../../../../content/core/shaders/core.fsh"));

        GL.CompileShader(vertexShader);

        GL.GetShader(vertexShader, ShaderParameterName.CompileStatus, out int vStatusVert);
        if (vStatusVert != (int) GLEnum.True)
            throw new Exception("[ShaderCompiler] [Fatal Error] Vertex shader failed to compile: " + GL.GetShaderInfoLog(vertexShader));

        GL.CompileShader(fragmentShader);
            
        GL.GetShader(fragmentShader, ShaderParameterName.CompileStatus, out int vStatusFrag);
        if (vStatusFrag != (int) GLEnum.True)
            throw new Exception("[ShaderCompiler] [Fatal Error] Fragment shader failed to compile: " + GL.GetShaderInfoLog(fragmentShader));
            

        GL.AttachShader(ShaderProgram, vertexShader);
        GL.AttachShader(ShaderProgram, fragmentShader);

        GL.LinkProgram(ShaderProgram);

        GL.GetProgram(ShaderProgram, ProgramPropertyARB.LinkStatus, out int lStatus);
        if (lStatus != (int) GLEnum.True)
            throw new Exception("[ShaderCompiler] Shader Program failed to link: " + GL.GetProgramInfoLog(ShaderProgram));
    }
    public void RenderAll()
    {   
        GL.ClearColor(Color.Blue);
        GL.BindVertexArray(VertexArrayObject);
        GL.UseProgram(ShaderProgram);
        GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
    }
    public void RunWindow() {
        GameWindow.Run();
    }
}
