namespace Game;
using Engine;
using Silk.NET.Input; 

public class GameManager : IGame
{
    Entity Cube;
    public void Initialise()
    {
        Cube = new Entity();
        Cube.Model = new Model();
    }

    Angles CameraAngles = new Angles(0, 0, 0);
	public void Frame() 
    {


            Cube.Rotation = Cube.Rotation.RotateAroundAxis(Vector3.Up, 0.8f * Time.Delta);
            var Speed = 2.0f * Time.Delta;
            if (Input.Down(Key.W))
            { 
                Camera.Position += Speed * Camera.Rotation.Forward;
            }
            if (Input.Down(Key.S))
            { 
                Camera.Position += Speed * Camera.Rotation.Backwards;
            }
            if (Input.Down(Key.A))
            { 
                Camera.Position += Speed * Camera.Rotation.Left;
            }
            if (Input.Down(Key.D))
            { 
                Camera.Position += Speed * Camera.Rotation.Right;
            }
            
            if (Input.Down(Key.Space))
            { 
                Camera.Position += Speed * Vector3.Up;
            }
            if (Input.Down(Key.ControlLeft))
            { 
                Camera.Position += Speed * Vector3.Down;
            }
             CameraAngles.Pitch += Input.MouseDelta.Y * 0.001f;
             CameraAngles.Yaw += Input.MouseDelta.X * -0.001f;

			Camera.Rotation =  Rotation.FromAngles(CameraAngles);

	}

    public void Tick() 
    {
            
            
            Cube.Position = new Vector3(0,-1.5f,0);

            Log.Info(Camera.Position.ToString());
            
            Log.Info(Camera.Rotation.Forward.ToString());
            
            Log.Info(Camera.Rotation.AsVec4().ToString());
            
            Log.Info(Camera.Rotation.AsVec4().ToString());
    }
    public void BuildInput() 
    {

    }
}
