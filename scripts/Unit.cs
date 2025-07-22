using Godot;

namespace script;

public partial class Unit : CharacterBody2D
{
    protected float ForwardSpeed { get; set; }
    protected float BackwardsSpeed { get; set; }
    protected float HullTurnSpeedDegrees { get; set; }
    protected float TurretTurnSpeedDegrees { get; set; }

}
