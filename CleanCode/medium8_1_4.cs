namespace CleanCode
{
    public class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }

    public class Movement
    {
        public float DirectionX { get; private set; }
        public float DirectionY { get; private set; }
        public float Speed { get; private set; }
        
        public void Move()
        {
            //Do move
        }
    }

    public class Player
    {
        private readonly Weapon _weapon = new Weapon();
        private readonly Movement _movement = new Movement();
        
        public string Name { get; private set; }
        public int Age { get; private set; }

        public void Attack()
        {
            //attack
        }
    }
}