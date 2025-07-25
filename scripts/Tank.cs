using Godot;
using System;

namespace Tankgamemain.scripts;

public partial class Tank : CharacterBody2D
{
    protected float ForwardSpeed { get; set; }
    protected float BackwardSpeed { get; set; }
    protected float HullTurnSpeed { get; set; }
    protected float TurretTurnSpeed { get; set; }

    private AnimatedSprite2D trackRight;
    private AnimatedSprite2D trackLeft;
    private Node2D turretNode;
    public override void _Ready()
    {
        base._Ready();
        trackRight = GetNode<AnimatedSprite2D>("Right track");
        trackLeft = GetNode<AnimatedSprite2D>("Left track");
        turretNode = GetNode<Node2D>("Turret node");
    }
    protected virtual void Movement(double delta) { }

    public override void _PhysicsProcess(double delta)
    {
        //movement
        //turret rotation
        var rotationDirection = Input.GetAxis("rotate_counterclockwise", "rotate_clockwise");//
        var movementDirection = Input.GetAxis("move_backward", "move_forvard");


        Move((float)delta, movementDirection, rotationDirection);
        AnimateTracks(rotationDirection, movementDirection);
        RotateTurret((float)delta);



    }

    protected void Move(float delta, float movementDirection, float rotationDirection)
    {
        var speed = (movementDirection > 0) ? ForwardSpeed : BackwardSpeed;//

        var backwardMoveAndTurnCorrection = movementDirection == -1 ? -1 : 1; //for "intuitive" backward movement
        Rotation += rotationDirection * backwardMoveAndTurnCorrection * HullTurnSpeed * delta;
        Velocity = movementDirection * Vector2.Up.Rotated(Rotation) * speed * delta;

        MoveAndCollide(Velocity);
    }
    protected void AnimateTracks(float movementDirection, float rotationDirection)
    {
        var leftSpeed = 0F;
        var rightSpeed = 0F;
        leftSpeed += movementDirection + 0.5F * rotationDirection;
        rightSpeed += movementDirection - 0.5F * rotationDirection;
        trackRight.SetSpeedScale(rightSpeed);
        trackLeft.SetSpeedScale(leftSpeed);
        trackRight.Play("Movement");
        trackLeft.Play("Movement");
    }
    
    protected void RotateTurret(float delta)
    {
        var cursorRelativeToTurret = GetGlobalMousePosition() - turretNode.GlobalPosition;
        var turretDirection = Vector2.Up.Rotated(turretNode.GlobalRotation);
        var deltaAngle = turretDirection.AngleTo(cursorRelativeToTurret);
        var direction = Math.Sign(deltaAngle);
        var rotationAmountMax = TurretTurnSpeed * (float)delta;
        var rotationAmountByDeltaAngle = Math.Abs(deltaAngle);

        turretNode.Rotation += (float)Math.Min(rotationAmountMax, rotationAmountByDeltaAngle) * direction;
    }
}
