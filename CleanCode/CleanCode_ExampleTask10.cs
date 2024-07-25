namespace CleanCode;

public partial class Program
{
    private class Weapon
    {
        private readonly int _bulletsPerShot = 1;
        private int _bullets;

        public bool CanShoot => _bullets >= _bulletsPerShot;

        public void Shoot()
        {
            if (_bullets <= _bulletsPerShot)
                throw new InvalidOperationException(nameof(_bullets));
            
            _bullets -= _bulletsPerShot;
        }
    }
}
