// using UnityEngine;

// public class RunState : State
// {
//   float gravityValue;
//   //bool jump;
//   Vector3 currentVelocity;
//   bool sprint;
//   float sprintSpeed;
//   Vector3 cVelocity;

//   public RunState(StateMachine _character, BaseStateMachine _stateMachine): base(_character, _stateMachine)
//   {
//     character = _character;
//     stateMachine = _stateMachine;
//   }
//    public override void Enter()
//   {
//     base.Enter();
//     //jump = false;
//     sprint = false;
//     input = Vector2.zero;
//     velocity = Vector3.zero;
//     currentVelocity = Vector3.zero;
//     gravityVelocity.y = 0;

//     sprintSpeed = character.SprintSpeed;
//     gravityValue = character.gravityValue;
//   }
//    public override void HandleInput()
//     {
//         base.HandleInput();
//         if(sprintAction.triggered || input.sqrMagnitude == 0f){
//             sprint = false;
//         }
//         else
//         {
//             sprint = true;
//         }
//         input = moveAction.ReadValue<Vector2>();
//         velocity = new Vector3(input.x, 0, input.y);
//         velocity = velocity.x * character.cameraTransform.right.normalized + velocity.z * character.cameraTransform.forward.normalized;
//         velocity.y = 0f;
//     }
//     public override void LogicUpdate()
//     {
//         base.LogicUpdate();
//         if(sprint)
//         {
//             character.animator.SetFloat("Velocity", input.magnitude + 0.5f, character.SpeedDampTime, Time.deltaTime); 
//         }
//         else
//         {
//             stateMachine.ChangeState(character.Standing);
//         }
//     }
//     public override void PhysicsUpdate()
//     {
//         base.PhysicsUpdate();
//         gravityVelocity.y += gravityValue * Time.deltaTime;
//         gravityVelocity.y = 0f;
//         currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, character.velocityDampTIme);
//         character.controller.Move(currentVelocity * Time.deltaTime * sprintSpeed + gravityVelocity * Time.deltaTime);

//         if (velocity.sqrMagnitude>0)
//         {
//           character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity),character.rotationDampTime);

//         }
//     }
// }
