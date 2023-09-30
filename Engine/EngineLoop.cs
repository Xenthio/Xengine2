using System.ComponentModel;
using System.Reflection;

namespace Engine;

public partial class Xengine 
{
    public bool DoEngineLoop = true;
    public int TicksPerSecond = 64;
    TimeSince TimeSinceTick = 0;
    public Assembly GameAssembly;
    public IGame GameManager;
    public void GameInitialise(string assemblyName) {

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
    public void EngineLoop() 
    {
        while (DoEngineLoop) 
        {
            GameManager.BuildInput();
            if (TimeSinceTick > TicksPerSecond/1f) {
                TimeSinceTick = 0;
                GameManager.Tick();
            }

            //Do Render Shite
            GameManager.Frame();
        }
    }

    
}