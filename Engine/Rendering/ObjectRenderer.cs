
namespace Render;

using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Engine;
using Silk.NET.OpenGL;

public class Scene 
{
    public static Scene CurrentScene = new Scene();
    public List<SceneObject> SceneObjects = new List<SceneObject>();

}
public class SceneCamera
{
    
}
public abstract class SceneObject 
{
    public Engine.Vector3 Position = new Engine.Vector3();
    public Rotation Rotation = Rotation.FromAngles(0,0,0);
    public Model Model = new();
    public SceneObject()
    {
        Scene.CurrentScene.SceneObjects.Add(this);
    }
    public virtual unsafe uint Render() 
    {
        if (Model != null)
        {
                Log.Info("RenderingModel"); 
                fixed (float* buf = Model.Vertices)
                    GameRenderer.GL.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (Model.Vertices.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);
                fixed (uint* buf = Model.Indices)
                    GameRenderer.GL.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint) (Model.Indices.Length * sizeof(uint)), buf, BufferUsageARB.StaticDraw);

                return (uint)Model.Indices.Length;
   
        } else {
            return 0;
        }
        
    }
}

public class Gizmo 
{
    public static Engine.Vector3 Position = new Engine.Vector3();
    public static Rotation Rotation = Rotation.FromAngles(0,0,0);
    public static float[] XVerts = 
    {
            // X     Y     Z       U     V       R     G     B     A
            0.0f, 0.0f, 0.0f,   0.0f, 0.0f,   1.0f, 0.0f, 0.0f, 1.0f,
            0.5f, 0.0f, 0.0f,   0.0f, 0.0f,   1.0f, 0.0f, 0.0f, 1.0f,
    };

    public static float[] YVerts = 
    {
            // X     Y     Z       U     V       R     G     B     A
            0.0f, 0.0f, 0.0f,   0.0f, 0.0f,   0.0f, 1.0f, 0.0f, 1.0f,
            0.0f, 0.5f, 0.0f,   0.0f, 0.0f,   0.0f, 1.0f, 0.0f, 1.0f,
    };

    public static float[] ZVerts = 
    {
            // X     Y     Z       U     V       R     G     B     A
            0.0f, 0.0f, 0.0f,   0.0f, 0.0f,   0.0f, 0.0f, 1.0f, 1.0f,
            0.0f, 0.0f, 0.5f,   0.0f, 0.0f,   0.0f, 0.0f, 1.0f, 1.0f,
    };
    public static unsafe void Render() {
        var GL = GameRenderer.GL;

        fixed (float* buf = XVerts)
            GameRenderer.GL.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (XVerts.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);
        
        GL.DrawArrays(PrimitiveType.Lines, 0, 256);

        fixed (float* buf = YVerts)
            GameRenderer.GL.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (YVerts.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);

        GL.DrawArrays(PrimitiveType.Lines, 0, 256);
        
        fixed (float* buf = ZVerts)
            GameRenderer.GL.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (ZVerts.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);

        GL.DrawArrays(PrimitiveType.Lines, 0, 256);
    }
    

}