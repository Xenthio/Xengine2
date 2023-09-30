using System.ComponentModel;
using System.Reflection;
using Engine;
using Render;

namespace Engine;

public static partial class Xengine 
{
    public static GameRenderer RenderInstance = new();
    public static bool DoEngineLoop = true;
    public static int TicksPerSecond = 64;
    static TimeSince TimeSinceTick = 0;
    public static Assembly GameAssembly;
    public static IGame GameManager;
    public static void GameInitialise(string assemblyName) {

        GameAssembly = Assembly.Load(assemblyName);

        foreach (var type in GameAssembly.GetTypes()) 
        {
            if (typeof(IGame).IsAssignableFrom(type)) {
                GameManager = (IGame)Activator.CreateInstance(type);
            }
        }
        if(GameManager == null) 
        {
            Log.Error("Error loading entry point in game assembly! Are you missing a class implementing IGame?");
            return;
        }
        GameManager.Initialise();
    }

    public static void BindGameEvents() {
        foreach (var type in GameAssembly.GetTypes()) 
        {
            foreach (var method in type.GetMethods())
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(GameEvent.Frame))) {
                    FrameEvents += (Action) Delegate.CreateDelegate(typeof(Action), method);
                }
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(GameEvent.Input))) {
                    InputEvents += (Action) Delegate.CreateDelegate(typeof(Action), method);
                }
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(GameEvent.Tick))) {
                    TickEvents += (Action) Delegate.CreateDelegate(typeof(Action), method);
                }
            }
        }
    }

    public static void SetupInput() 
    {
        Xengine.RenderInstance.InitialiseInput();
        Input.SetupInput();
    }

    internal static Action FrameEvents;

    internal static Action InputEvents;

    internal static Action TickEvents;
    static public void OnFrame(double deltaTime) 
    {
        //Do Render Shite
        FrameEvents?.Invoke();
        GameManager.Frame();
        RenderInstance.RenderAll();
    }
    static public void OnTick(double deltaTime)
    {
        TickEvents?.Invoke();
        GameManager.Tick();
    }
    static public void OnInput()
    {
        InputEvents?.Invoke();
        GameManager.BuildInput();
    }

    static public void OnLoad()
    {
        // Setup Input
        SetupInput();
        RenderInstance.InitialiseGL();
    }
    
}