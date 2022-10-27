 using UnityEngine;
 using UnityEngine.InputSystem;

 public class State
 {
    public StateMachine character;
    public BaseStateMachine stateMachine;

    protected Vector3 gravityVelocity;
    protected Vector3 velocity;
    protected Vector2 input;
  
    public InputAction moveAction;
    public InputAction lookAction;
    public InputAction sprintAction;
    public InputAction rollAction;
    public State(StateMachine _character, BaseStateMachine _stateMachine)
    {
         character = _character;
         stateMachine = _stateMachine;

         moveAction = character.playerInput.actions["Move"];
         sprintAction = character.playerInput.actions["Sprint"];
         rollAction = character.playerInput.actions["Roll"];
      // lookAction = character.playerInput.actions["look"];

    }
    public virtual void Enter()
    {
         //Debug.Log("enter state: "+this.ToString());
    }
    public virtual void HandleInput()
    {
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void PhysicsUpdate()
    {
    }
    public virtual void Exit()
    {
    }
 }
