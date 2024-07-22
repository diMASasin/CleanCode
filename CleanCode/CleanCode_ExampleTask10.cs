namespace MethodName;

public partial class Program
{
    private class Weapon
    {
        private int _bullets;
        private readonly int _bulletsPerShot = 1;

        public bool CanShoot() => _bullets >= _bulletsPerShot;

        public void Shoot() => _bullets -= _bulletsPerShot;
    }
}