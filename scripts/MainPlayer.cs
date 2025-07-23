using System;
using Godot;

namespace Tankgamemain.scripts;

public partial class MainPlayer : Unit
{
    public override void _Ready()
    {
        base._Ready();
        //TODO move to the config when there will be more then 1 tank option
        ForwardSpeed = 60;
        BackwardSpeed = 20;
        HullTurnSpeed = (float)45 / 180 * (float)Math.PI;
        TurretTurnSpeed = (float)45 / 180 * (float)Math.PI;
    }

    public override void _PhysicsProcess(double delta)
    {
        var rotationDirection = Input.GetAxis("rotate_counterclockwise", "rotate_clockwise");
        var movementDirection = Input.GetAxis("move_backward", "move_forvard");
        var speed = (movementDirection > 0) ? ForwardSpeed : BackwardSpeed;

        Rotation += rotationDirection * movementDirection * HullTurnSpeed * (float)delta; //here we mult also by movementDirection for "intuitive" backward movement
        Velocity = movementDirection * Vector2.Up.Rotated(Rotation) * speed * (float)delta;

        MoveAndCollide(Velocity);
    }
}
