// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PlayerMovement : MonoBehaviour
// {
//     // Start is called before the first frame update
//     PlayerInput playerInput;
//     CharacterController characterController;
//     Animator animator;
//     Vector2 CurrentMovementInput;
//     Vector3 CurrentMovement;
//     Vector3 CurrentRunMovement;
//     bool isMovePressed;
//     bool isRunPressed;
//     float rotationFactorPerFrame = 12.0f;

//     private void Awake() {
//         playerInput = new PlayerInput();

//         characterController = GetComponent<CharacterController>();

//         animator = GetComponent<Animator>();

//         playerInput.CharacterControl.Movement.started += onMovementInput;

//         playerInput.CharacterControl.Movement.canceled += onMovementInput;

//         playerInput.CharacterControl.Movement.performed += onMovementInput;

//         playerInput.CharacterControl.Sprint.started += OnRun;
//         playerInput.CharacterControl.Sprint.canceled += OnRun;
//         playerInput.CharacterControl.Sprint.performed += OnRun;
//      }
//     // Update is called once per frame


//     void OnRun(InputAction.CallbackContext context)
//     {
//         isRunPressed = context.ReadValueAsButton();
//     }
//     void onMovementInput(InputAction.CallbackContext context)
//     {
//         CurrentMovementInput = context.ReadValue<Vector2>();
//         CurrentMovement.x = CurrentMovementInput.x;
//         CurrentMovement.z = CurrentMovementInput.y;
//         CurrentRunMovement.x = CurrentMovementInput.x * 3.0f;
//         CurrentRunMovement.z = CurrentMovementInput.y * 3.0f;
//         isMovePressed = CurrentMovementInput.x != 0 || CurrentMovementInput.y != 0;
//     }
//     void handleGravity()
//     {
//         if(characterController.isGrounded)
//         {
//             float GroundGravity = -0.5f;
//             CurrentMovement.y = GroundGravity;
//             CurrentRunMovement.y = GroundGravity;
//         }else
//         {
//             float Gravity = -9.8f;
//             CurrentMovement.y += Gravity;
//             CurrentRunMovement.y += Gravity;
//         }
//     }

//     void handleAnimation()
//     {
//         bool isWalking = animator.GetBool("IsWalking");
//         bool isRunning = animator.GetBool("IsRunning");

//         if (isMovePressed && !isWalking){
//             animator.SetBool("IsWalking", true);
//         }
//         else if(!isMovePressed && isWalking){
//             animator.SetBool("IsWalking", false);
//         }
//         else if((isMovePressed && isRunPressed) && !isRunning)
//         {
//             animator.SetBool("IsRunning", true);
//         }
//         else if((!isMovePressed || !isRunPressed) && isRunning)
//         {
//             animator.SetBool("IsRunning", false);
//         }

//     }

//     void handleRotation()
//     {
//         Vector3 positionToLookAt;

//         positionToLookAt.x = CurrentMovement.x;
//         positionToLookAt.y = 0.0f;
//         positionToLookAt.z = CurrentMovement.z;

//         Quaternion currentRotation = transform.rotation;

//         if(isMovePressed)
//         {
//             Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
//             transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
//         }

//     }
//     void Update()
//     {   
//         handleRotation();
//         handleAnimation();
//         if(isRunPressed)
//         {
//             characterController.Move(CurrentRunMovement * Time.deltaTime);
//         }
//         else
//         {
//             characterController.Move(CurrentMovement * Time.deltaTime);
//         }
//     }

//     private void OnEnable() {
//         playerInput.CharacterControl.Enable();
//     }
//     private void OnDisable() {
//         playerInput.CharacterControl.Disable();
//     }
// }
