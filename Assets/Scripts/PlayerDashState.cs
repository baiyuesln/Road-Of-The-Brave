using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }
 
    public override void Exit()
    {
        player.SetVelocity(0, rb.velocity.y); 
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.dashSpeed * player.dashDir, 0); 
        if(stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
        if(player.IsWallDetected()&&!player.IsGroudDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }
    }
}
