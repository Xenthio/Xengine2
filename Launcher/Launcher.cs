using Engine;
using System;
using Render;
using Silk.NET.Input;

internal class Launcher 
{
    public static void Main(string[] args) 
    {
        Log.Info("Xengine started!");

        // init render
        Xengine.RenderInstance.InitialiseWindow("Game");
        
        // Load game assembly
        Xengine.GameInitialise("Game");
        Xengine.BindGameEvents();
        //Xengine.RenderInstance.GameWindow.UpdatesPerSecond = Xengine.TicksPerSecond;

        // Setup Engine loop
        Xengine.RenderInstance.GameWindow.Render += Xengine.OnFrame;
        Xengine.RenderInstance.GameWindow.Update += Xengine.OnTick;
        Xengine.RenderInstance.GameWindow.Load += Xengine.OnLoad;

        // Swap to loop
        Log.Info("Switching to Engine Loop...");
        Xengine.RenderInstance.RunWindow();

        Log.Info("Shutting down!");
    }
}
