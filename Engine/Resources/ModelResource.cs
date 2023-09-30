namespace Engine;
#nullable disable
public class Model
{
    public float[] Vertices = 
    {
        0.5f,  0.5f, 0.0f,
        0.5f, -0.5f, 0.0f,
        -0.5f, -0.5f, 0.0f,
        -0.5f,  0.5f, 0.0f
    };
    public uint[] Indices = 
    {
        0u, 1u, 3u,
        1u, 2u, 3u
    };
}
