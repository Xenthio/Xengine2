using Engine;
using System;
using Render;

internal class Launcher 
{
    public static Xengine EngineInstance = new();
    
    public static Renderer RenderInstance = new();
    public static void Main(string[] args) 
    {
        Log.Info("Xengine started!");

        // Load game assembly
        EngineInstance.GameInitialise("Game");
        // init render
        RenderInstance.InitialiseWindow("Game");
        RenderInstance.InitialiseRenderContext();

        
        // Run engine loop
        EngineInstance.EngineLoop();

        Log.Info("Shutting down!");
    }
}
