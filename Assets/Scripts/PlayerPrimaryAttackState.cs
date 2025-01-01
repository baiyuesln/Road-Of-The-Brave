using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 2;
    public PlayerPrimaryAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
        {
            comboCounter = 0;
        }
        player.anim.SetInteger("ComboCounter", comboCounter);

        #region Choose Attack Status
        float attackDir = player.facingDir;
        if(xInput != 0)
        {
            attackDir = xInput;
        }
        player.anim.speed = 1.2f;
        player.SetVelocity(player.attackMovement[comboCounter].x*attackDir,player.attackMovement[comboCounter].y);
        #endregion

        stateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;
        player.anim.speed = 1f;
        Debug.Log(lastTimeAttacked);
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0)
        {
            player.ZeroVelocity();   
        }
        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}

