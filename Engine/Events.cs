namespace Engine;

public class GameEvent
{
    
[AttributeUsage(AttributeTargets.Method)]
public class Input : Attribute
{
    // . . .
}
[AttributeUsage(AttributeTargets.Method)]
public class Frame : Attribute
{
    // . . .
}
[AttributeUsage(AttributeTargets.Method)]
public class Tick : Attribute
{
    // . . .
}
}