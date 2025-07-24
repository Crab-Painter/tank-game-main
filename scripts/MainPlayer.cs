using System;
using Godot;

namespace Tankgamemain.scripts;

public partial class MainPlayer : Unit
{
    public override void _Ready()
    {
        base._Ready();
        //TODO move to the config when there will be more then 1 tank option
        ForwardSpeed = UnitConversion.Import("37 km/h");
        BackwardSpeed = UnitConversion.Import("15 km/h");
        HullTurnSpeed = UnitConversion.Import("45 deg/s");
        TurretTurnSpeed = UnitConversion.Import("45 deg/s");
    }

    public override void _PhysicsProcess(double delta)
    {
        var rotationDirection = Input.GetAxis("rotate_counterclockwise", "rotate_clockwise");
        var movementDirection = Input.GetAxis("move_backward", "move_forvard");
        var speed = (movementDirection > 0) ? ForwardSpeed : BackwardSpeed;

        var backwardMoveAndTurnCorrection = movementDirection == -1 ? -1 : 1; //for "intuitive" backward movement
        Rotation += rotationDirection * backwardMoveAndTurnCorrection * HullTurnSpeed * (float)delta;
        Velocity = movementDirection * Vector2.Up.Rotated(Rotation) * speed * (float)delta;

        MoveAndCollide(Velocity);
    }
}
