using Silk.NET.Input;

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