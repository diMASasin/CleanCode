namespace CleanCode;

public class CleanCode_ExampleTask15
{
    public class PlayerStatistics { }
    public class Gun { }
    public class TargetFollower{ }
    public class Team
    {
        public IReadOnlyCollection<Unit> Units { get; private set; }
    }
}

public class Unit
{
}