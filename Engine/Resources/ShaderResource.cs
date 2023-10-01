using System.Numerics;
using Render;
using Silk.NET.OpenGL;

namespace Engine;

public class Shader : IDisposable
    {
        private uint _handle;
        private GL GL;

        public static Shader Load(string path) 
        {
            return new Shader(path);
        }

        public Shader(string path)
        {
            GL = GameRenderer.GL;

            var fragmentPath = path + ".fsh";
            var vertexPath = path + ".vsh";


            uint vertex = LoadShader(ShaderType.VertexShader, vertexPath);
            uint fragment = LoadShader(ShaderType.FragmentShader, fragmentPath);
            _handle = GL.CreateProgram();
            GL.AttachShader(_handle, vertex);
            GL.AttachShader(_handle, fragment);
            GL.LinkProgram(_handle);
            GL.GetProgram(_handle, GLEnum.LinkStatus, out var status);
            if (status == 0)
            {
                throw new Exception($"Program failed to link with error: {GL.GetProgramInfoLog(_handle)}");
            }
            GL.DetachShader(_handle, vertex);
            GL.DetachShader(_handle, fragment);
            GL.DeleteShader(vertex);
            GL.DeleteShader(fragment);
        }

        public void Use()
        {
            GL.UseProgram(_handle);
        }

        public void SetUniform(string name, int value)
        {
            int location = GL.GetUniformLocation(_handle, name);
            if (location == -1)
            {
                throw new Exception($"{name} uniform not found on shader.");
            }
            GL.Uniform1(location, value);
        }

        public void SetAttribute(string name, Vector3 value)
        {
            uint positionLoc = (uint)GL.GetAttribLocation(_handle, name);
            GL.EnableVertexAttribArray(positionLoc);
            float[] pos = {value.x,value.y,value.z};
            unsafe {
                GL.VertexAttribPointer(positionLoc, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), (void*) 0 );
            }
        }

        public unsafe void SetUniform(string name, Matrix4x4 value)
        {
            //A new overload has been created for setting a uniform so we can use the transform in our shader.
            int location = GL.GetUniformLocation(_handle, name);
            if (location == -1)
            {
                throw new Exception($"{name} uniform not found on shader.");
            }
            GL.UniformMatrix4(location, 1, false, (float*) &value);
        }

        public void SetUniform(string name, float value)
        {
            int location = GL.GetUniformLocation(_handle, name);
            if (location == -1)
            {
                throw new Exception($"{name} uniform not found on shader.");
            }
            GL.Uniform1(location, value);
        }

        public void Dispose()
        {
            GL.DeleteProgram(_handle);
        }

        private uint LoadShader(ShaderType type, string path)
        {
            string src = File.ReadAllText(path);
            uint handle = GL.CreateShader(type);
            GL.ShaderSource(handle, src);
            GL.CompileShader(handle);
            string infoLog = GL.GetShaderInfoLog(handle);
            if (!string.IsNullOrWhiteSpace(infoLog))
            {
                throw new Exception($"Error compiling shader of type {type}, failed with error {infoLog}");
            }

            return handle;
        }
    }