using Render; 
using Silk.NET.Input;
using System.Numerics;

namespace Engine;

public static class Input 
{ 
    internal static void SetupInput() 
    {
        for (int i = 0; i < Xengine.RenderInstance.Input.Keyboards.Count; i++)
        {
            Xengine.RenderInstance.Input.Keyboards[i].KeyDown += OnKeyDown;
            Xengine.RenderInstance.Input.Keyboards[i].KeyUp += OnKeyUp;
        }
		for (int i = 0; i < Xengine.RenderInstance.Input.Mice.Count; i++)
		{
            Xengine.RenderInstance.Input.Mice[i].Cursor.CursorMode = CursorMode.Raw;
			Xengine.RenderInstance.Input.Mice[i].MouseMove += OnMouseMove;
			Xengine.RenderInstance.Input.Mice[i].MouseDown += OnMouseDown;
		}
	}
    public static bool LockMouse = true;
    public static Vector2 MouseDelta = new Vector2(0,0);
	public static Vector2 MousePosition = new Vector2(0, 0);
    static Vector2 _lastmousepos = new Vector2(0, 0);
	public static void BuildInput()
	{

        for (int i = 0; i < Xengine.RenderInstance.Input.Mice.Count; i++)
        {
            Xengine.RenderInstance.Input.Mice[i].Cursor.CursorMode = LockMouse ? CursorMode.Raw : CursorMode.Normal;
        }
		Log.Info(MouseDelta.ToString());
		MouseDelta = MousePosition - _lastmousepos;
		_lastmousepos = Input.MousePosition;

	}
	internal static void OnMouseMove(IMouse mouse, Vector2 position)    
    {
        MousePosition = position;
	}

	internal static void OnMouseDown(IMouse mouse, MouseButton button)
	{
		Log.Info(button.ToString());
	}

	internal static void OnKeyDown(IKeyboard keyboard, Key key, int keyCode) 
    {
        Log.Info(key.ToString());

    }
     
    internal static void OnKeyUp(IKeyboard keyboard, Key key, int keyCode) 
    {
        Log.Info(key.ToString());

    }

    public static bool Down(Key key)
    {
        for (int i = 0; i < Xengine.RenderInstance.Input.Keyboards.Count; i++)
        {
            if (Xengine.RenderInstance.Input.Keyboards[i].IsKeyPressed(key)) return true;
        }
        return false;
    }
    public static bool Pressed(Key key)
    {
        return false;
    }
}