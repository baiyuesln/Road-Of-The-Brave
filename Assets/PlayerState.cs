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
        rb = player.rb;
    }   


    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.velocity.y); 
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        Debug.Log("I Exit " + animBoolName);
    }
}

