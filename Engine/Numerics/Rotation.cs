using System.Numerics;

namespace Engine;

public class Rotation
{
    public Quaternion quat = Quaternion.Identity;

    public Rotation(Quaternion quatinit)
    {
        quat = quatinit;
    }
    public Rotation()
    {
        quat = Quaternion.Identity;
    }

    public Vector3 Forward => System.Numerics.Vector3.Transform(Vector3.Forward, quat);
    public Vector3 Backwards => System.Numerics.Vector3.Transform(Vector3.Backwards, quat);
    public Vector3 Left => System.Numerics.Vector3.Transform(Vector3.Left, quat);
    public Vector3 Right => System.Numerics.Vector3.Transform(Vector3.Right, quat);
    public Vector3 Up => System.Numerics.Vector3.Transform(Vector3.Up, quat);
    public Vector3 Down => System.Numerics.Vector3.Transform(Vector3.Down, quat);

    public Vector4 AsVec4()
    {
        return new Vector4(quat.X,quat.Y,quat.Z,quat.W);
    }
    public Rotation Inverse() 
    {
        return new Rotation(Quaternion.Inverse(quat));
    }
    public Rotation RotateAroundAxis(Vector3 axis, float angle)
    {
        return new Rotation(quat * Quaternion.CreateFromAxisAngle(axis,angle));
    }
    public static Rotation FromAngles(Angles angles)
    {
        return new Rotation(Quaternion.CreateFromYawPitchRoll(angles.Yaw,angles.Pitch,angles.Roll));
    }
    public static Rotation FromAngles(float yaw, float pitch, float roll)
    {
        return new Rotation(Quaternion.CreateFromYawPitchRoll(yaw,pitch,roll));
    }
    
    public static Rotation FromAxisAngle(Vector3 axis, float angle)
    {
        return new Rotation(Quaternion.CreateFromAxisAngle(axis,angle));
    }
    public static Rotation operator *(Rotation value1, Rotation value2)
    {
        return new Rotation(Quaternion.Multiply(value1.quat,value2.quat));
    }
    public static Rotation operator /(Rotation value1, Rotation value2)
    {
        return new Rotation(Quaternion.Divide(value1.quat,value2.quat));
    }
     public static Rotation operator +(Rotation value1, Rotation value2)
    {
        return new Rotation(Quaternion.Add(value1.quat,value2.quat));
    }
    public static Rotation operator - (Rotation value1, Rotation value2)
    {
        return new Rotation(Quaternion.Subtract(value1.quat,value2.quat));
    }
}
