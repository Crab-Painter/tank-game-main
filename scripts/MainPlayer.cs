using System;
using Godot;

namespace Tankgamemain.scripts;

public partial class MainPlayer : Tank
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

    protected override TankControlsInputDTO GetControlsInput()
    {
        
        return new TankControlsInputDTO(
            Input.GetAxis("move_backward", "move_forvard"),
            Input.GetAxis("rotate_counterclockwise", "rotate_clockwise"),
            Input.IsActionJustPressed("fire_gun")
        );
    }

}
