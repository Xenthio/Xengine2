namespace Game;

using System.Diagnostics.Tracing;
using Engine;
public class FPSCounter
{
    [GameEvent.Frame]
    public static void FPSLog() 
    {
       // Log.Info(Xengine.TicksPerSecond);
    }
}
