
namespace Render;

using System.Numerics;
using Engine;
using Silk.NET.OpenGL;


public abstract class SceneObject 
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Model Model = new();
    public SceneObject()
    {
        Xengine.RenderInstance.GameWindow.Render += OnRender;
    }
    public virtual unsafe void OnRender(double deltaTime) 
    {
        if (Model != null)
        {
                Log.Info("RenderingModel"); 
                fixed (float* buf = Model.Vertices)
                    GameRenderer.GL.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (Model.Vertices.Length * sizeof(float)), buf, BufferUsageARB.DynamicDraw);
                fixed (uint* buf = Model.Indices)
                    GameRenderer.GL.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint) (Model.Indices.Length * sizeof(uint)), buf, BufferUsageARB.DynamicDraw);
   
        }
    }
}