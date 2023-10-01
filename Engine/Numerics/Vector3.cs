using System.Numerics;

namespace Engine;

public static class Vector3Extensions
{
    internal static Vector3 ToGL(this Vector3 vec3)
    {
        return new Vector3(vec3.x,vec3.z,vec3.y);
    }
}

public class Vector3
{   
    public float x;
    public float y;
    public float z;
	/*
    public static Vector3 Forward => new Vector3(1,0,0);
    public static Vector3 Backwards => new Vector3(-1,0,0);
    public static Vector3 Left => new Vector3(0,1,0);
    public static Vector3 Right => new Vector3(0,-1,0);
    public static Vector3 Up => new Vector3(0,0,1);
    public static Vector3 Down => new Vector3(0,0,-1);
    */
	public static Vector3 Forward => new Vector3(0, 0, 1);
	public static Vector3 Backwards => new Vector3(0, 0, -1);
	public static Vector3 Left => new Vector3(1, 0, 0);
	public static Vector3 Right => new Vector3(-1, 0, 0);
	public static Vector3 Up => new Vector3(0, 1, 0);
	public static Vector3 Down => new Vector3(0, -1, 0);

	public Vector3(float X, float Y, float Z)
    {
        x = X;
        y = Y;
        z = Z;
    }
    public Vector3()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public override string ToString()
    {
        return $"Vector3({x}, {y}, {z})";
    }

    public static implicit operator System.Numerics.Vector3(Vector3 d) => new System.Numerics.Vector3(d.x, d.y, d.z);
    public static implicit operator Vector3(System.Numerics.Vector3 b) => new Vector3(b.X,b.Y,b.Z);

    public static Vector3 operator *(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
    }
    public static Vector3 operator /(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
    }
    public static Vector3 operator +(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }
    public static Vector3 operator -(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }

    public static Vector3 operator *(Vector3 v1, float v2)
    {
        return new Vector3(v1.x * v2, v1.y * v2, v1.z * v2);
    }
    public static Vector3 operator /(Vector3 v1, float v2)
    {
        return new Vector3(v1.x / v2, v1.y / v2, v1.z / v2);
    }
    public static Vector3 operator +(Vector3 v1, float v2)
    {
        return new Vector3(v1.x + v2, v1.y + v2, v1.z + v2);
    }
    public static Vector3 operator -(Vector3 v1, float v2)
    {
        return new Vector3(v1.x - v2, v1.y - v2, v1.z - v2);
    }

    public static Vector3 operator *(float v1, Vector3 v2)
    {
        return new Vector3(v1 * v2.x, v1 * v2.y, v1 * v2.z);
    }
    public static Vector3 operator /(float v1, Vector3 v2)
    {
        return new Vector3(v1 / v2.x, v1 / v2.y, v1 / v2.z);
    }
    public static Vector3 operator +(float v1, Vector3 v2)
    {
        return new Vector3(v1 + v2.x, v1 + v2.y, v1 + v2.z);
    }
    public static Vector3 operator -(float v1, Vector3 v2)
    {
        return new Vector3(v1 - v2.x, v1 - v2.y, v1 - v2.z);
    }


}
