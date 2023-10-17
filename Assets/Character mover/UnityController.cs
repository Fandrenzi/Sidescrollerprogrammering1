using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;

    public CharacterState JumpingState = CharacterState.Airborne;
 
    public float GravityPerSecond = 160.0f; 
    public float GroundLevel = 0.0f; 

   
    public float JumpSpeedFactor = 3.0f; 
    public float JumpMaxHeight = 150.0f;
    [SerializeField]
    private float JumpHeightDelta = 0.0f;
   
    public float MovementSpeedPerSecond = 10.0f; 





    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;
        characterVelocity.y = 0.0f;

        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; 
            JumpHeightDelta = 0.0f; 
        }

        if (JumpingState == CharacterState.Jumping)
        {

            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y += totalJumpMovementThisFrame;

            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;

    }
}


