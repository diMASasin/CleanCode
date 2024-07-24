namespace CleanCode;

public class CleanCode_ExampleTask30
{
    public void Enable() => _effects.StartEnableAnimation();
    
    public void Disable() => _pool.Free(this);
}
