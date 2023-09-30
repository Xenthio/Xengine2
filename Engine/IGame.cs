namespace Engine;

public interface IGame 
{
    public void Initialise();
    public void Frame();
    public void Tick();
    public void BuildInput();
}