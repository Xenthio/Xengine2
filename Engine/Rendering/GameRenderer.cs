using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using System.Drawing;
using Engine;
using System.Numerics;

namespace Render;

public partial class GameRenderer
{
    internal static uint VertexArrayObject;
    internal static uint VertexBufferObject;
    internal static uint ElementBufferObject;
    internal Engine.Shader CurrentShader;
    internal Engine.Texture DefaultTexture;
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
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, VertexBufferObject);

        ElementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, ElementBufferObject);
        
        GL.ClearColor(System.Drawing.Color.Black);

        CompileShaders();
        DefaultTexture = Engine.Texture.Load("../../../../content/core/textures/default.jpg");

            
    }

    public void CompileShaders() 
    {
        //var VertShaderCode = File.ReadAllText("../../../../content/core/shaders/core.vsh");
        //var FragShaderCode = File.ReadAllText("../../../../content/core/shaders/core.fsh");
        CurrentShader = Engine.Shader.Load("../../../../content/core/shaders/core");
    }
    uint positionLoc = 0;

    public void RenderAll()
    {   

        GL.Enable(EnableCap.DepthTest);
        GL.Clear((uint) (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));

        
        GL.BindVertexArray(VertexArrayObject);
        
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, VertexBufferObject);
        GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, ElementBufferObject);

        CurrentShader.Use();
        
        unsafe {
            
            // Model Format;
            //vertices
                var offset = 0;
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), (void*)((offset) * sizeof(float)) );
                offset += 3;
                GL.EnableVertexAttribArray(0);
            
            //uv
                GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 9 * sizeof(float), (void*)((offset) * sizeof(float)) );
                offset += 2;
                GL.EnableVertexAttribArray(1);

            //vertex colours
                GL.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, 9 * sizeof(float), (void*)((offset) * sizeof(float)) );
                offset += 3;
                GL.EnableVertexAttribArray(2);
        }

        //setup camera


        //var view = Matrix4x4.CreateLookAt(Camera.Position, Camera.Position + Camera.Rotation.Forward, Camera.Rotation.Up);
        //var view = Matrix4x4.CreateLookTo(Camera.Position, Camera.Position + Camera.Rotation.Forward, Camera.Rotation.Up);
        //var view = Matrix4x4.CreateTranslation(Camera.Position) * Matrix4x4.CreateFromQuaternion(Camera.Rotation.quat);
		var view = Matrix4x4.CreateLookAt(Camera.Position, Camera.Position + Camera.Rotation.Forward, Camera.Rotation.Up);

		var projection = Matrix4x4.CreatePerspectiveFieldOfView(DegToRad(80), 16f / 9f, 0.1f, 100f);


            
        //GL.UniformMatrix4() (&view[0][0]);

        foreach (var sceneObject in Scene.CurrentScene.SceneObjects )
        {
            
            unsafe {

                CurrentShader.Use();
                uint indcount = sceneObject.Render();
                // render position
                
                //CurrentShader.SetAttribute("aPosition", sceneObject.Position);
                
                var model = Matrix4x4.CreateFromQuaternion(sceneObject.Rotation.quat) * Matrix4x4.CreateTranslation(sceneObject.Position);
                
                //var model = Matrix4x4.Decompose
                DefaultTexture.Bind();
                CurrentShader.SetUniform("uTexture0", 0);
                CurrentShader.SetUniform("view", view);
                CurrentShader.SetUniform("projection", projection);
                CurrentShader.SetUniform("model", model);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 256);

                
                //GL.DrawElements(PrimitiveType.Triangles, 256, DrawElementsType.UnsignedInt, 0);
            }
            
            
            var model2 = Matrix4x4.CreateFromQuaternion(Gizmo.Rotation.quat) * Matrix4x4.CreateTranslation(Gizmo.Position);
            CurrentShader.SetUniform("uTexture0", 0);
            CurrentShader.SetUniform("view", view);
            CurrentShader.SetUniform("projection", projection);
            CurrentShader.SetUniform("model", model2);
            Gizmo.Render();
            //GL.DrawElements(PrimitiveType.Triangles, indcount, DrawElementsType.UnsignedInt, 0);
        }
        
        //GL.DrawArrays(PrimitiveType.Triangles, 0, 256);
        

    }

    float DegToRad(float deg)
    {
        return (MathF.PI / 180) * deg;
    }
    public void RunWindow() {
        GameWindow.Run();
    }
}
