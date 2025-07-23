using System;
using Godot;

namespace Tankgamemain.scripts;

public partial class Turret : MainPlayer
{
    public override void _PhysicsProcess(double delta)
    {
        var cursorRelativeToTurret = GetGlobalMousePosition() - GlobalPosition;
        var turretDirection = Vector2.Up.Rotated(GlobalRotation);
        var deltaAngle = turretDirection.AngleTo(cursorRelativeToTurret);
        var direction = Math.Sign(deltaAngle);
        var rotationAmountMax = TurretTurnSpeed * (float)delta;
        var rotationAmountByDeltaAngle = Math.Abs(deltaAngle);       

        Rotation += (float)Math.Min(rotationAmountMax, rotationAmountByDeltaAngle) * direction;
    }
}
