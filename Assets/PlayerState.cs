using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName) 
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {   
        player.anim.SetBool(animBoolName, true);
        Debug.Log("I Enter " + animBoolName);
    }   

    public virtual void Exit()
    {
        Debug.Log("I Exit " + animBoolName);
    }

    public virtual void Update()
    {
        player.anim.SetBool(animBoolName, false);
        Debug.Log("I Update " + animBoolName);
        
        
    }
}

