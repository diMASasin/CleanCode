namespace MethodName;

public class CleanCode_ExampleTask15
{
    public class PlayerData { }
    public class Gun { }
    public class TargetFollower{ }
    public class Units
    {
        public IReadOnlyCollection<Unit> Value { get; private set; }
    }
}

public class Unit
{
}