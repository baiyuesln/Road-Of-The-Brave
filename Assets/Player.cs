using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public PlayerStateMachine stateMachine { get; private set; }
    #endregion

    #region States
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion


    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
