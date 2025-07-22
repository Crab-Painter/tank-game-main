using System;
using Godot;

namespace script;

public partial class Turret : MainPlayer
{
    public override void _Process(double delta)
    {
        var cursorRelativeToTurret = GetGlobalMousePosition() - GlobalPosition;
        var turretDirection = Vector2.Up.Rotated(GlobalRotation);
        var deltaAngle = turretDirection.AngleTo(cursorRelativeToTurret);
        var direction = Math.Sign(deltaAngle);
        var rotationAmountMax = TurretTurnSpeedDegrees * (float)delta;
        var rotationAmountByDeltaAngle = Math.Abs(double.RadiansToDegrees(deltaAngle));       

        RotationDegrees += (float)Math.Min(rotationAmountMax, rotationAmountByDeltaAngle) * direction;
    }
}
