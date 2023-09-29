using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total
}
public class Charactermover : MonoBehaviour
{
   public CharacterState JumpingState = CharacterState.Airborne;
 
        void Start()
    {
        
    }
    public float Gravitypersecond = 160.0f;
    public float Groundlevel = 0.0f;

    public float JumpSpeedFactor = 3.0f;
    public float JumpMaxHeight = 150;
    [SerializeField]
    public float JumpHeightDelta = 0.0f;

    public float MovementSpeedpersecond = 10.0f;
 

    void Update()
    {
        bool isMoving = false;
        if (isMoving == false)
        {
            Vector3 Gravityposition = transform.position;
            Gravityposition.y -= Gravitypersecond * Time.deltaTime;
            if (Gravityposition.y < Groundlevel) { Gravityposition.y = Groundlevel; }
            transform.position = Gravityposition;
            isMoving = true;
        }


        if(transform.position.y <= Groundlevel)
        {
            Vector3 CharacterPosition = transform.position;
            CharacterPosition.y -= Groundlevel;
            transform.position = CharacterPosition;
            JumpingState = CharacterState.Grounded;
        }
        //up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            //Vector3 characterposition = transform.position;
            //characterposition.y += MovementSpeedpersecond * Time.deltaTime;
            //transform.position = characterposition;
            //isMoving = true;

            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
        if(JumpingState== CharacterState.Jumping)
        {
            Vector3 Characterposition = transform.position;
            float currentPositon = Characterposition.y;
            float totalJumpMovementThisFrame = MovementSpeedpersecond * JumpSpeedFactor * Time.deltaTime;
            Characterposition.y += totalJumpMovementThisFrame;
            transform.position = Characterposition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterposition = transform.position;
            characterposition.x -= MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

        //down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterposition = transform.position;
            characterposition.y -= MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterposition = transform.position;
            characterposition.x += MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

    }
}