using Godot;

namespace script;

public partial class MainPlayer : Unit
{
    public override void _Ready()
    {
        base._Ready();
        //TODO move to the config when there will be more then 1 tank option
        ForwardSpeed = 60;
        BackwardsSpeed = 20;
        HullTurnSpeedDegrees = 45;
        TurretTurnSpeedDegrees = 45;
    }

    public override void _Process(double delta)
    {
        //TODO there should be more scalable way to do this probbably
        if (Input.IsActionPressed("move_forvard"))
        {
            var Velocity = Vector2.Up.Rotated(Rotation) * ForwardSpeed;
            Position += Velocity * (float)delta;
        }

        if (Input.IsActionPressed("move_backwards"))
        {
            var Velocity = Vector2.Up.Rotated(Rotation) * BackwardsSpeed;
            Position -= Velocity * (float)delta;
        }

        if (Input.IsActionPressed("turn_right"))
        {
            RotationDegrees += HullTurnSpeedDegrees * (float)delta;
        }

        if (Input.IsActionPressed("turn_left"))
        {
            RotationDegrees -= HullTurnSpeedDegrees * (float)delta;
        }

        
    }
}
