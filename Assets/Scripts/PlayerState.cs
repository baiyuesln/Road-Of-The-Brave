using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;
    protected float stateTimer;
    protected bool triggerCalled;
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
        rb = player.rb;
        triggerCalled = false;
    }   


    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y); 
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false); 
        Debug.Log("I Exit " + animBoolName);
    }

    public virtual void AnimationTrigger() => triggerCalled = true;
}

