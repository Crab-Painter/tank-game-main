namespace Tankgamemain.scripts
{
    public class TankControlsInputDTO(float movementDirection, float rotationDirection)
    {
        private float _movementDirection = movementDirection;
        private float _rotationDirection = rotationDirection;

        public float MovementDirection { get { return _movementDirection; } }
        public float RotationDirection { get { return _rotationDirection; } }
    }
}