namespace Engine;

using System.Numerics;

public static class Camera
{
    public static Vector3 Position = new Vector3(0,0,0);
    public static Rotation Rotation = Rotation.FromAxisAngle(Vector3.Forward, 0);
}