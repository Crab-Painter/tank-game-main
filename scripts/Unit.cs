using Godot;

namespace script;

public partial class Unit : CharacterBody2D
{
    protected float ForwardSpeed { get; set; }
    protected float BackwardSpeed { get; set; }
    protected float HullTurnSpeed { get; set; }
    protected float TurretTurnSpeed { get; set; }

}
