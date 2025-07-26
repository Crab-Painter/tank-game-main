namespace Tankgamemain.scripts
{
    public class TankControlsInputDTO(float movementDirection, float rotationDirection, bool isGunShot)
    {
        private float _movementDirection = movementDirection;
        private float _rotationDirection = rotationDirection;
        private bool _isGunShot = isGunShot;

        public float MovementDirection { get { return _movementDirection; } }
        public float RotationDirection { get { return _rotationDirection; } }
        public bool IsGunShot { get { return _isGunShot; } }

    }
}